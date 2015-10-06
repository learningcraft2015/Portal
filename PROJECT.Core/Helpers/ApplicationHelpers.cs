using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Helpers
{
  public  class ApplicationHelpers
    {

      public static string GetAppSettingsKey(string keyName)
      {
          if (System.Configuration.ConfigurationManager.AppSettings[keyName] != null)
              return System.Configuration.ConfigurationManager.AppSettings[keyName].ToString();
          else
              throw new ArgumentException("a key with the name " + keyName + " doesn't exists in the current configurations", keyName);
      }


      /// <summary>
      /// Deletes the file.
      /// </summary>
      /// <param name="file">The file.</param>
      /// <returns></returns>
      public static bool DeleteFile(String file)
      {
          try
          {
              System.IO.File.SetAttributes(file, FileAttributes.Normal);
              System.IO.File.Delete(file);
          }
          catch (Exception ex)
          {
              return false;
          }
          return true;
      }

    }
}
