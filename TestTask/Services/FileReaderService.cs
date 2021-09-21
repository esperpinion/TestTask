using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TestTask.Models;

namespace TestTask.Services
{
    public static class FileReaderService
    {
        public static List<FileRecord> GetRecordsFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            var fileRecords = new List<FileRecord>();

            FileRecord fileRecord = new FileRecord();

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.IndexOf(' ') < 0)
                    {
                        MessageBox.Show("Ошибка чтения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return fileRecords;
                    }

                    string command = line.Substring(0, line.IndexOf(' '));
                    string record = line.Substring(line.IndexOf(' ') + 1).Trim('"');

                    switch (command)
                    {
                        case "msgctxt":
                            fileRecord.Context = record;
                            break;
                        case "msgid":
                            fileRecord.Id = record;
                            break;
                        case "msgstr":
                            fileRecord.Text = record;
                            break;
                        default:
                            MessageBox.Show(
                                $"В строке {Array.IndexOf(lines, line)} найдена неизвестная команда {command}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                            break;
                    }
                }
                else
                {
                    //пустая строка - разделитель записей
                    if (fileRecord.Id != null)
                    {
                        fileRecords.Add(fileRecord);
                        fileRecord = new FileRecord();
                    }
                }
            }

            if (fileRecord.Id != null) //последняя запись
            {
                fileRecords.Add(fileRecord);
            }

            return fileRecords;
        }
    }
}
