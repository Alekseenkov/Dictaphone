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
        /// <summary>
        /// ////////////колхоз переделать 
        /// </summary>
        // WaveIn - поток для записи
        WaveIn waveIn;
        //Класс для записи в файл
        WaveFileWriter writer;
        //Имя файла для записи
        //string outputFilename = @"D:\DistaphoneMedia\1.wav";


        //////////////
        ///
        List<string> Filenames = new List<string>();




        /// <summary>
        /// //////////
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        void updateFileList()
        {
            ////////говнокод 

            for (int i = 0; i <10; i++)
            {
                Filenames.Add("");
            }

            comboBox1.Items.Clear();
            var dir = new DirectoryInfo(@"D:\DistaphoneMedia\");// папка с файлами 
            // var files = new List<string>(); // список для имен файлов 

            foreach (FileInfo file in dir.GetFiles()) // извлекаем все файлы и кидаем их в список 
            {
                string numfile = file.Name.Substring(0, 1);

                // Filenames.Add(file.Name);//имя файла 
                Filenames[Convert.ToInt32(numfile)] = file.FullName;// получаем полный путь к файлу и кидаем его в список 
                comboBox1.Items.Add(file.Name);
                //comboBox1.Items.Add(file.Name.Substring(0, 1));
            }

        }



        //Получение данных из входного буфера 
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            }
            else
            {
                //Записываем данные из буфера в файл
                writer.WriteData(e.Buffer, 0, e.BytesRecorded);
            }
        }
        //Завершаем запись
        void StopRecording()
        {
            // MessageBox.Show("StopRecording");
            timer1.Enabled = false;
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

        private void buttonNo_Click(object sender, EventArgs e)
        {

        }

        private void buttonYes_Click(object sender, EventArgs e)
        {

        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //////
            WaveStream mainOutputStream = new WaveFileReader(@"D:\DistaphoneMedia\" + comboBox1.SelectedItem.ToString());
            WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);

            WaveOutEvent player = new WaveOutEvent();

            player.Init(volumeStream);
            player.Play();

        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                StopRecording();
            }

        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {//////
              //треш в том что при загрузке в листе файлов
               // нет пропусков на месте файлов кроторых нет 

           // пиздец это нужно как нибудь решать 


            //проверка списка файлов 
            if (Filenames.IndexOf("") == -1)
            {
                MessageBox.Show("Места нет Удалите записи");
            }
            else {
                int findex = Filenames.IndexOf("");
                Filenames[findex]= @"D:\DistaphoneMedia\" + findex.ToString() + ".wav";

            //}

            //if (Filenames.Count == 10)
            //{
            //    MessageBox.Show("места нет");
            //}
            //else
           // {
                Filenames.Add(@"D:\DistaphoneMedia\" + Filenames.Count.ToString() + ".wav");


                ////////// старт таймера на запись 
                timer1.Enabled = true;

                ////////////

                try
                {
                    //  MessageBox.Show("Start Recording");
                    waveIn = new WaveIn();
                    //Дефолтное устройство для записи (если оно имеется)
                    waveIn.DeviceNumber = 0;
                    //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                    waveIn.DataAvailable += waveIn_DataAvailable;
                    //Прикрепляем обработчик завершения записи
                    waveIn.RecordingStopped += waveIn_RecordingStopped;

                    // waveIn.RecordingStopped += new EventHandler(waveIn_RecordingStopped);

                    //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                    waveIn.WaveFormat = new WaveFormat(8000, 1);
                    //Инициализируем объект WaveFileWriter
                    //writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                    writer = new WaveFileWriter(Filenames[findex], waveIn.WaveFormat);
                    //Начало записи
                    waveIn.StartRecording();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        int recordTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            recordTime++;
            /////////////////////
            if (recordTime > 10) {
                if (waveIn != null)
                {
                    StopRecording();
                }


            }

            ///////////////////////////////
            labelTimeRecord.Text = recordTime.ToString();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           
            //////удаление файла из списка 
            Filenames[Filenames.IndexOf(@"D:\DistaphoneMedia\" + comboBox1.SelectedItem.ToString())] = "";
            /////удаление файлов из папки 
            File.Delete(@"D:\DistaphoneMedia\" + comboBox1.SelectedItem.ToString());

            ///обновление комбо бокса
            updateFileList();
            comboBox1.Text = "";


        }
    }
}

