using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ZendeskUtility
{
    internal class SoundEffect
    {
       public String FilePath { get; set; }
        public String Name {get; set; }
        SoundPlayer Effect = null;
        public SoundEffect(string name, string path)
        {
            this.Name = name;
            this.FilePath = path;
            Effect = new SoundPlayer(path);
        }
        public void PlaySound()
        {
            try
            {

                Effect.Play();
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }
        public void LoopSound()
        {
            try
            {

                Effect.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void StopSound()
        {
            try
            {

                Effect.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
