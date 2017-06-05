using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LateBindingWordSaveAs
{
    public enum Formats
    {
        Pdf = 17,
        Docx = 16,
        Odt = 23,
        Html = 8
    }

    public class WordWrapper
    {
        public object CreateWordDoc(object fileName, object wordApplication, bool isReadonly)
        {
            object wordDocument = null;
            if (File.Exists(fileName.ToString()) && wordApplication != null)
            {
                object readOnly = isReadonly;
                object isVisible = true;
                object missing = Missing.Value;

                object wordDocuments = GetProperty("Documents", wordApplication);
                wordDocument = InvokeMember("Open", wordDocuments,
                    new object[]{fileName, missing,
                                    isReadonly, missing, missing, missing,
                                    missing, missing, missing, missing,
                                    missing, isVisible});
            }

            return wordDocument;
        }

        public object CreateWordApplication()
        {
            string message = "Failed to create word application. Check whether"
                + " word installation is correct.";
            Type wordType = Type.GetTypeFromProgID("Word.Application");
            if (wordType == null)
            {
                throw new Exception(message);
            }
            object wordApplication = Activator.CreateInstance(wordType);
            if (wordApplication == null)
            {
                throw new Exception(message);
            }

            return wordApplication;
        }

        public bool CloseWordDoc(object wordDocument, bool canSaveChange)
        {
            bool isSuccess = false;
            if (wordDocument != null)
            {
                object saveChanges = null;
                if (canSaveChange)
                {
                    saveChanges = -1; // Save Changes
                }
                else
                {
                    saveChanges = 0; // No changes
                }
                InvokeMember("Close", wordDocument, new object[] { saveChanges });
                isSuccess = true;
            }
 
            return isSuccess;
        }

        public bool CloseWordApp(object wordApplication)
        {
            bool isSuccess = false;
            if (wordApplication != null)
            {
                object saveChanges = -1; // Save changes
                InvokeMember("Quit", wordApplication, new object[] { saveChanges });
                isSuccess = true;
            }

            return isSuccess;
        }

        public bool SaveAs(object wordDocument, string path, string saveName, Formats format)
        {
            bool isSuccess = false;
            object oSaveAsFile = $"{path}\\{saveName}";
            object fileFormat = (int)format;
            if(wordDocument != null)
            {
                InvokeMember("SaveAs", wordDocument, new object[] { oSaveAsFile, fileFormat });
                isSuccess = true;
            }

            return isSuccess;
        }

        private object InvokeMember(string method, object instance, object[] parameters)
        {
            Type type = instance.GetType();
            return type.InvokeMember(method,
                BindingFlags.InvokeMethod, null, instance, parameters);
        }

        private object GetProperty(string propertyName, object instance)
        {
            Type type = instance.GetType();
            return type.InvokeMember(propertyName,
                BindingFlags.GetProperty, null, instance, new object[] { });
        }
    }
}
