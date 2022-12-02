using System.IO;
using System.Net.FtpClient;
using System.Net;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;
        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new NetworkCredential("mantis","test");
            client.Connect();
        }

        public void BackupFile (string path)
        {
            string backUpPath = path + ".bak";
            if (client.FileExists(backUpPath))
            {
                return;
            }
            client.Rename(path, backUpPath);
        }

        public void RestoreBackupFile(string path)
        {
            string backUpPath = path + ".bak";
            if (! client.FileExists(backUpPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backUpPath, path);
        }

        public void Upload(string path, Stream localfile)
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            using (Stream ftpStream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localfile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localfile.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
