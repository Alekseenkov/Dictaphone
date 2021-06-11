using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;
using System.IO;

namespace Dictaphone
{
    class Dictaphone
    {
        public WaveIn waveIn { get; set; }                                    // WaveIn - поток для записи
        public WaveFileWriter writer { get; set; }
        public WaveOutEvent player { get; set; } = new();
        public Memory memory { get; } = new();
        public int recordTime { get; set; }                                 //время записи соообщения 

        public Dictaphone() {
            recordTime = 0;
        }

        public void updateListFile()
        {
            memory.loadFileList();
        }

        public void StopRecording()
        {
            recordTime = 0;
            waveIn.StopRecording();
            updateListFile(); ///обновление комбо бокса
        }
       
        public void Play(string file)
        {
            player.Stop();
               // Console.WriteLine(file);
               var mainOutputStream = new WaveFileReader(@"D:\DistaphoneMedia\" + file);
                var volumeStream = new WaveChannel32(mainOutputStream);

                player.Init(volumeStream);
                player.Play();
        }

        public void Record_ON()
        {
            try
            {
                var  findex = memory.Filenames.IndexOf("");                                       //индекс пистого места куда можнот записать файл 
                memory.Filenames[findex] = findex.ToString() + ".wav";   //в списке файлов создаем путь записи файла 
                    var fullNameFile = memory.Directory + memory.Filenames[findex];

                
                    //  MessageBox.Show("Start Recording");
                    waveIn = new WaveIn();
                    waveIn.DeviceNumber = 0;                                                //Дефолтное устройство для записи (если оно имеется)
                    //waveIn.DataAvailable += waveIn_DataAvailable;                           //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                    
                    //writer.WriteData(WaveInEventArgs.Buffer, 0, WaveInEventArgs.BytesRecorded);             //Записываем данные из буфера в файл
                    //waveIn.RecordingStopped += waveIn_RecordingStopped;                     //Прикрепляем обработчик завершения записи
                    waveIn.WaveFormat = new WaveFormat(8000, 1);                            //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                    writer = new WaveFileWriter(fullNameFile, waveIn.WaveFormat);      //Инициализируем объект WaveFileWriter

                    waveIn.StartRecording();      //Начало записи
                                                  //  timer1.Enabled = true;   // запуск таймера на запись 
                                                  //buttonRecord.BackgroundImage = Properties.Resources.off;                //смена картинки на кнопке 
                }
                catch (Exception ex)
                {
                     //  MessageBox.Show(ex.Message);
                }
            
        }

        public void Record_OFF()
        {
                if (waveIn != null)
                    StopRecording();     //остановка записи
        }

        public void deleteFile(string file)
        {
            memory.deleteFile(file);      //удаление файла из памяти 
            memory.loadFileList();        //обновление листа 
           
        }

        public void Stop()
        {
            player.Stop();
        }


    }

}

