using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dictaphone
{
    class Memory
    {
        public List<string> Filenames { get; set; } = new();
        public string fileRecord { get; set; } = "";

        public string Directory { get; } = @"D:\DistaphoneMedia\";

        public Memory()
        {

            for (int i = 0; i < 10; i++)                             //добавление в список 10 "null"строк 
                Filenames.Add("");
        }

        public void loadFileList()
        {
            var dir = new DirectoryInfo(@"D:\DistaphoneMedia\");     // папка с файлами 

            foreach (FileInfo file in dir.GetFiles())               // извлекаем все файлы и кидаем их в список 
            {
                string numfile = file.Name.Substring(0, 1);
                Filenames[Convert.ToInt32(numfile)] = file.Name;    // получаем полный путь к файлу и кидаем его в список 
              
            }

        }

        public bool isFreeSpace()  // проверка на наличие места для записи возвращает (правду если есть свободное место) 
        {
            return Filenames.IndexOf("") != -1;
        }

        // получает параметром файл (1.вав) удаляет файл из директории и обновляет лист  
        public void deleteFile(string file)   
        {
            
            Filenames[Filenames.IndexOf(file)] = "";                  //////удаление файла из списка 
            File.Delete(Directory + file);                            /////удаление файлов из папки 
           
        }




    }
}
