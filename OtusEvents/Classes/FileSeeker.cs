﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusEvents.Classes
{
    public class FileSeeker
    {
        public event EventHandler<FileSeekerArgs> OnFileFound;


        private event Action OnCancel;
        private string _workDir = string.Empty;

        public FileSeeker(string workDir)
        {
            _workDir = workDir;

        }

        public void Cancel()
        {
            OnCancel?.Invoke();
        }
        public void RunSearchFiles()
        {
            using (var file = Directory.EnumerateFiles(_workDir).GetEnumerator())
            {
                WaitKeyPressTask();
                bool Cancel = false;
                this.OnCancel += () => Cancel = true;
                while (file.MoveNext())
                {
                    var args = new FileSeekerArgs() { FileName = file.Current };
                    OnFileFound?.Invoke(this, args);

                    if (Cancel)
                    {
                        Console.WriteLine("Операция прервана!");
                        break;
                    }
                    Thread.Sleep(50);

                }

            }


        }

        void WaitKeyPressTask()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        Cancel();
                        break;
                    }
                }
            });
        }


    }
}