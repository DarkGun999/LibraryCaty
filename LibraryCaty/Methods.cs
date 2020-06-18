using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryCaty
{
    class Methods
    {
        public static void BPMCaty(string path, ProgressBar lcStatus)
        {
            var files = new DirectoryInfo(path).GetFiles("*.mp3", SearchOption.TopDirectoryOnly).Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToList();

            // Progressbar
            lcStatus.Maximum = files.Count();

            // DirectoryCheck
            if (!Directory.Exists(path + "/EDMSoft"))
            {
                Directory.CreateDirectory(path + "/EDMSoft");
            }
            if (!Directory.Exists(path + "/EDMMiddle"))
            {
                Directory.CreateDirectory(path + "/EDMMiddle");

            }
            if (!Directory.Exists(path + "/EDMHard"))
            {
                Directory.CreateDirectory(path + "/EDMHard");

            }

            foreach (var file in files)
            {
                string fullFileName = file.FullName;
                lcStatus.Value++;

                TagLib.File f = TagLib.File.Create(fullFileName);
                int BPM = Convert.ToInt32(f.Tag.BeatsPerMinute);

                if (BPM < 110)
                {
                    // Low
                    File.Copy(fullFileName, path + "/EDMSoft/" + file.Name, true);
                }
                else if (BPM < 125)
                {
                    // Middle
                    File.Copy(fullFileName, path + "/EDMMiddle/" + file.Name, true);
                }
                else
                {
                    // Fast
                    File.Copy(fullFileName, path + "/EDMHard/" + file.Name, true);
                }
            }
        }

        public static void NewSongsCaty(string path, ProgressBar lcStatus)
        {
            var files = new DirectoryInfo(path).GetFiles("*.mp3", SearchOption.TopDirectoryOnly).Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToList();
            //Progressbar
            lcStatus.Maximum = files.Count();

            foreach (var file in files)
            {
                string fullFileName = file.FullName;
                lcStatus.Value = +1;

                if (fullFileName.Contains("Remix"))
                {
                    if (!Directory.Exists(path + "/Remix"))
                    {
                        Directory.CreateDirectory(path + "/Remix");
                    }
                    File.Copy(fullFileName, path + "/Remix/" + file.Name);
                }
                else
                {

                    TagLib.File f = TagLib.File.Create(fullFileName);
                    string[] Genres = f.Tag.Genres;

                    foreach (var Genre in Genres)
                    {
                        if (Genre == "Trap")
                        {
                            // EDM
                            if (!Directory.Exists(path + "/Remix"))
                            {
                                Directory.CreateDirectory(path + "/Remix");
                            }
                            File.Copy(fullFileName, path + "/EDM/" + file.Name);
                        }
                        else if (Genre == "Hip Hop")
                        {
                            // HipHop
                            if (!Directory.Exists(path + "/HipHop"))
                            {
                                Directory.CreateDirectory(path + "/HipHop");
                            }
                            File.Copy(fullFileName, path + "/HipHop/" + file.Name);
                        }
                        else
                        {
                            // Unrecognized
                            if (!Directory.Exists(path + "/Unrecognized"))
                            {
                                Directory.CreateDirectory(path + "/Unrecognized");
                            }
                            File.Copy(fullFileName, path + "/Unrecognized/" + file.Name);
                        }
                    }
                }
            }
        }
    }
}
