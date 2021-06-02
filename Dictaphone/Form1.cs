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

        //Завершаем запись
        void StopRecording()
        {
            dictaphone.StopRecording();
            timer1.Enabled = false;                 //выключение таймера записи 
            labelTimeRecord.Text = ".....";
           
            updateFileList();         ///обновление комбо бокса
            comboBox1.Text = "";
            buttonRecord.BackgroundImage = Properties.Resources.on;    //смена картинки на кнопке 
        }
        //Окончание записи
        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
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

        private void Form1_Load(object sender, EventArgs e)
        {
            updateFileList();
        }

       

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                dictaphone.Play(comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select the recording to play!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        

        bool stateButtonRecord = true;
        private void buttonRecord_Click(object sender, EventArgs e)
        {//////
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
                    catch (Exception ex){
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("No space \n Delete audio recordings!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            dictaphone.recordTime++;
            
            if ((dictaphone.recordTime > 10) && (dictaphone.waveIn != null))
                StopRecording();
            labelTimeRecord.Text = dictaphone.recordTime.ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try {
                dictaphone.deleteFile(comboBox1.SelectedItem.ToString());
                updateFileList();                                    ///обновление комбо бокса
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            dictaphone.Stop();
        }
        
    }
}

