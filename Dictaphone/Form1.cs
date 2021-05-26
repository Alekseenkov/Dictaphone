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
        WaveIn waveIn;                                                                            // WaveIn - поток для записи
        WaveFileWriter writer;                                                                    //Класс для записи в файл

        List<string> Filenames = new();

        /// <summary>
        /// //////////
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        void updateFileList()
        {
            for (int i = 0; i < 10; i++)                                                            //добавление в список 10 "null"строк 
                Filenames.Add("");

            comboBox1.Items.Clear();
            var dir = new DirectoryInfo(@"D:\DistaphoneMedia\");     // папка с файлами 

            foreach (FileInfo file in dir.GetFiles()) // извлекаем все файлы и кидаем их в список 
            {
                string numfile = file.Name.Substring(0, 1);
                Filenames[Convert.ToInt32(numfile)] = file.FullName;// получаем полный путь к файлу и кидаем его в список 
                comboBox1.Items.Add(file.Name);
            }
        }



        //Получение данных из входного буфера 
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            else
#pragma warning disable CS0618 // Тип или член устарел
                writer.WriteData(e.Buffer, 0, e.BytesRecorded);             //Записываем данные из буфера в файл
#pragma warning restore CS0618 // Тип или член устарел
        }
        //Завершаем запись
        void StopRecording()
        {
            // MessageBox.Show("StopRecording");
            timer1.Enabled = false;                 //выключение таймера записи 
            labelTimeRecord.Text = ".....";
            recordTime = 0;
            //////////////
            waveIn.StopRecording();
            ///обновление комбо бокса
            updateFileList();
            comboBox1.Text = "";
        }
        //Окончание записи
        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(waveIn_RecordingStopped), sender, e);
            }
            else
            {
                waveIn.Dispose();
                waveIn = null;
                writer.Close();
                writer = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateFileList();

        }

        //private void buttonNo_Click(object sender, EventArgs e)
        //{

        //}

        //private void buttonYes_Click(object sender, EventArgs e)
        //{

        //}

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            var fileFullName = @"D:\DistaphoneMedia\" + comboBox1.SelectedItem.ToString();
            var mainOutputStream = new WaveFileReader(fileFullName);

            var volumeStream = new WaveChannel32(mainOutputStream);
            var player = new WaveOutEvent();

            player.Init(volumeStream);
            player.Play();

        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            //if (waveIn != null)
            //    StopRecording();
        }

        bool stateButtonRecord = true;
        private void buttonRecord_Click(object sender, EventArgs e)
        {//////
            stateButtonRecord = !stateButtonRecord;

            if (stateButtonRecord)
            {
                this.buttonRecord.BackgroundImage = global::Dictaphone.Properties.Resources.on;    //смена картинки на кнопке 

                if (waveIn != null)
                    StopRecording();     //остановка записи 
            }
            else
            {
                this.buttonRecord.BackgroundImage = global::Dictaphone.Properties.Resources.off;      //смена картинки на кнопке 
 
                if (Filenames.IndexOf("") == -1)                                              //проверка списка файлов на наличие свободного места 
                    MessageBox.Show("Места нет \n Удалите записи");
                else
                {
                    int findex = Filenames.IndexOf("");                                       //индекс пистого места куда можнот записать файл 
                    Filenames[findex] = @"D:\DistaphoneMedia\" + findex.ToString() + ".wav";   //в списке файлов создаем путь записи файла 
                        
                    try
                    {
                        //  MessageBox.Show("Start Recording");
                        waveIn = new WaveIn();
                        waveIn.DeviceNumber = 0;                                                //Дефолтное устройство для записи (если оно имеется)
                        waveIn.DataAvailable += waveIn_DataAvailable;                           //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                        waveIn.RecordingStopped += waveIn_RecordingStopped;                     //Прикрепляем обработчик завершения записи
                        waveIn.WaveFormat = new WaveFormat(8000, 1);                             //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                        writer = new WaveFileWriter(Filenames[findex], waveIn.WaveFormat);       //Инициализируем объект WaveFileWriter

                        waveIn.StartRecording();      //Начало записи
                        timer1.Enabled = true;   // запуск таймера на запись 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


        }

        int recordTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            recordTime++;
            /////////////////////    если не работает вынести второе условие в тело цикла if 
            if ((recordTime > 10) && (waveIn != null))
            {
                StopRecording();
            }
            ///////////////////////////////
            labelTimeRecord.Text = recordTime.ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            var fileFullName = @"D:\DistaphoneMedia\" + comboBox1.SelectedItem.ToString();

            Filenames[Filenames.IndexOf(fileFullName)] = "";      //////удаление файла из списка 
            File.Delete(fileFullName);                            /////удаление файлов из папки 
            updateFileList();                                    ///обновление комбо бокса
            comboBox1.Text = "";
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

