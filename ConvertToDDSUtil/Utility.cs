using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToDDSUtil
{
    public class Utility
    {

        public static bool WriteLatestAllLogFile(string allOutput)
        {
            return Utility.WriteToFile("Logs\\texconv-all-output-latest", allOutput, FileMode.OpenOrCreate);
        }

        public static bool WriteLatestFailedLogFile(string failedOutput)
        {
            return Utility.WriteToFile("Logs\\texconv-failed-output-latest", failedOutput, FileMode.OpenOrCreate);
        }

        public static bool WriteAllLogFile(string allOutput)
        {
            return Utility.WriteToFile("Logs\\texconv-all-output", allOutput, FileMode.Append);
        }

        public static bool WriteFailedLogFile(string failedOutput)
        {
            return Utility.WriteToFile("Logs\\texconv-failed-output", failedOutput, FileMode.Append);
        }

        public static bool HasWriteAccessToFolder(string folderPath)
        {
            string testFileName = folderPath + "writetest";
            try
            {
                using (FileStream fs = new FileStream(testFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.WriteByte(0xff);
                }

                if (File.Exists(testFileName))
                {
                    File.Delete(testFileName);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public static bool WriteToFile(string file, string contents, FileMode mode)
        {
            try
            {
                using (FileStream fs = new FileStream(file, mode, FileAccess.Write))
                {
                    using (TextWriter writer = new StreamWriter(fs))
                    {
                        writer.Write(contents);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool MoveFile(string src, string destPath)
        {
            return Utility.MoveFile(src, destPath, false);
        }

        public static bool MoveFile(string src, string destPath, bool rename)
        {
            string renamePrependStr = string.Empty;
            if (rename)
            {
                renamePrependStr = Guid.NewGuid().ToString();
            }

            return Utility.MoveFile(src, destPath, rename, renamePrependStr);
        }

        public static bool MoveFile(string src, string destPath, bool rename, string renamePrependStr)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(src);
                string fileExt = Path.GetExtension(src);

                string final;

                if (rename)
                {
                    final = fileName + "-" + renamePrependStr + fileExt;
                }
                else
                {
                    final = fileName + fileExt;
                }

                File.Move(src, destPath + "\\" + final);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
