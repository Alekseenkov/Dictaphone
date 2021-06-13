using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;
using System.IO;

namespace Dictaphone
{
    public partial class Form1 : Form
    {
        private Dictaphone dictaphone = new();

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(90, 90, 90);
            labelChargePercent.Text ="40%";  
        }
        void updateFileList()
        {
            comboBox1.Items.Clear();
            dictaphone.updateListFile();
            foreach (string file in dictaphone.memory.Filenames)               // извлекаем все файлы и кидаем их в список 
            {
                if (file!="")
                comboBox1.Items.Add(file);
            }
        }

        //Получение данных из входного буфера 
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            else
#pragma warning disable CS0618 // Тип или член устарел
                dictaphone.writer.WriteData(e.Buffer, 0, e.BytesRecorded);             //Записываем данные из буфера в файл
#pragma warning restore CS0618 // Тип или член устарел
        }

        void PowerMode() {
                if (OperatingMode.chargePercent > 20)
                {
                OperatingMode.isModeDictaphone = !OperatingMode.isModeDictaphone;
                OperatingMode.isModeDictaphoneTime = 0;
                }
        }

        //Завершаем запись
        void StopRecording()
        {
            if (!OperatingMode.isModeDictaphone)
                PowerMode();
            else
            {
                OperatingMode.isModeDictaphoneTime = 0;

                dictaphone.StopRecording();
                timer1.Enabled = false;                 //выключение таймера записи 
                labelTimeRecord.Text = ".....";

                updateFileList();         ///обновление комбо бокса
                comboBox1.Text = "";
                buttonRecord.BackgroundImage = Properties.Resources.on;    //смена картинки на кнопке 
            }
        }
        //Окончание записи
        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            if (!OperatingMode.isModeDictaphone)
                PowerMode();
            ////сработает при нажитии если режим до нажития энергосберегающий 
            else
            {
                OperatingMode.isModeDictaphoneTime = 0;
                /// действие кнопки 

                if (this.InvokeRequired)
                    this.BeginInvoke(new EventHandler(waveIn_RecordingStopped), sender, e);
                else
                {
                    dictaphone.waveIn.Dispose();
                    dictaphone.waveIn = null;
                    dictaphone.writer.Close();
                    dictaphone.writer = null;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateFileList();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!OperatingMode.isModeDictaphone)
                PowerMode();
            else
            {
                OperatingMode.isModeDictaphoneTime = 0;
                try
                {
                    //timer1.Enabled = false;                 //выключение таймера записи 
                    //labelTimeRecord.Text = ".....";
                    dictaphone.Stop();
                    dictaphone.Play(comboBox1.SelectedItem.ToString());
                    //timer1.Enabled = true;   // запуск таймера при воспроизведени
                }
                catch (Exception)
                {
                    MessageBox.Show("Select the recording to play!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        

        bool stateButtonRecord = true;
        private void buttonRecord_Click(object sender, EventArgs e)
        {//////
            if (!OperatingMode.isModeDictaphone)
                PowerMode();
            ////сработает при нажитии если режим до нажития энергосберегающий 
            else
            {
                OperatingMode.isModeDictaphoneTime = 0;
               
                stateButtonRecord = !stateButtonRecord;

                if (stateButtonRecord)
                    StopRecording();                    //остановка записи 
                else
                {
                    if (dictaphone.memory.isFreeSpace())                                              //проверка списка файлов на наличие свободного места 
                    {
                        try
                        {
                            dictaphone.Record_ON();
                            dictaphone.waveIn.DataAvailable += waveIn_DataAvailable;                           //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                            dictaphone.waveIn.RecordingStopped += waveIn_RecordingStopped;                     //Прикрепляем обработчик завершения записи
                            dictaphone.waveIn.WaveFormat = new WaveFormat(8000, 1);                            //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)

                            timer1.Enabled = true;   // запуск таймера на запись 
                            buttonRecord.BackgroundImage = Properties.Resources.off;                //смена картинки на кнопке 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("No space \n Delete audio recordings!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            dictaphone.recordTime++;
            
            if ((dictaphone.recordTime > 10) && (dictaphone.waveIn != null))
                StopRecording();
            //if (dictaphone.recordTime < 10)
            //    labelTimeRecord.Text = dictaphone.recordTime.ToString();
            //else
            //    labelTimeRecord.Text = "....";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!OperatingMode.isModeDictaphone)
                PowerMode();
            ////сработает при нажитии если режим до нажития энергосберегающий 
            else
            {
                OperatingMode.isModeDictaphoneTime = 0;
                /// действие кнопки 

                try
                {
                    dictaphone.deleteFile(comboBox1.SelectedItem.ToString());
                    updateFileList();                                    ///обновление комбо бокса
                    comboBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (!OperatingMode.isModeDictaphone)
                PowerMode();
            ////сработает при нажитии если режим до нажития энергосберегающий 
            else
            {
                OperatingMode.isModeDictaphoneTime = 0;
                /// действие кнопки 
                //timer1.Enabled = false;                 //выключение таймера записи 
                //labelTimeRecord.Text = ".....";
                dictaphone.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            labelChargePercent.Text = OperatingMode.chargePercent.ToString() + "%";   // вывод процента заряда 

            if (OperatingMode.chargePercent>20)                                       // условие окраски процента заряда 
                labelChargePercent.ForeColor = Color.Black;
            else 
                labelChargePercent.ForeColor = Color.Red;

            if (OperatingMode.charging && OperatingMode.chargePercent < 100)         // условие зарядки батареи 
                OperatingMode.chargePercent++;

            if (!OperatingMode.charging && OperatingMode.chargePercent > 5)         // условие разрядки батареи 
                OperatingMode.chargePercent -= 2;

            if (OperatingMode.isModeDictaphoneTime > 10 
                && OperatingMode.chargePercent > 20)                           //переход из энергосберегающего режима  
                OperatingMode.isModeDictaphone = false;


            if (OperatingMode.isModeDictaphone) {
               // labelModeDictaphone.Text = "обычный";
                this.BackColor = Color.FromArgb(255,255,255);
            }
            else{
              //  labelModeDictaphone.Text = "энергосберегающий";
                this.BackColor = Color.FromArgb(90, 90, 90);
            } 

            OperatingMode.isModeDictaphoneTime++;

           // labelTimeMode.Text = OperatingMode.isModeDictaphoneTime.ToString();   // таймер режима 
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                OperatingMode.charging = true;
            else
                OperatingMode.charging = false;

        }
    }
}

