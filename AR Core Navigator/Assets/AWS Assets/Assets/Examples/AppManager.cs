using Amazon.S3.Model;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace AWSSDK.Examples
{
    public class AppManager : MonoBehaviour
    {
        public string S3BucketName;
        public string fileNameOnBucket;
        private string pathFileUpload;
        public Text resultTextOperation;
        public InputField UploadInputField;

        void Start()
        {
            
            StreamWriter writer = new StreamWriter(Application.persistentDataPath+@"/"+System.DateTime.Now.ToString("yy.MM.dd")+".json", true);
            //fileNameOnBucket = System.DateTime.Now.ToString("yy.MM.dd")+".json";
            writer.WriteLine("goofy");
            writer.Close();
            StreamWriter writer2 = new StreamWriter(Application.persistentDataPath+@"/"+System.DateTime.Now.ToString("yy.MM.dd")+".csv", true);
            //fileNameOnBucket = System.DateTime.Now.ToString("yy.MM.dd")+".csv";
            writer2.WriteLine("goofy");
            writer2.Close();
            
            //pathFileUpload = (Application.persistentDataPath+@"/"+System.DateTime.Now.ToString("yy.MM.dd")+".json");
            S3Manager.Instance.OnResultGetObject += GetObjectBucket;
        }

        void Update()
        {
            fileNameOnBucket = UploadInputField.text;    
        }
        public void ListObjectsBucket()
        {
            resultTextOperation.text = "Fetching all the Objects from " + S3BucketName;

            S3Manager.Instance.ListObjectsBucket(S3BucketName, (result, error) =>
            {
                resultTextOperation.text += "\n";
                if (string.IsNullOrEmpty(error))
                {
                    resultTextOperation.text += "Got Response \nPrinting now \n";
                    result.S3Objects.ForEach((o) =>
                    {
                        resultTextOperation.text += string.Format("File: {0}\n", o.Key);
                    });
                }
                else
                {
                    print("Get Error:: " + error);
                    resultTextOperation.text += "Got Exception \n";
                }
            });
        }

        public void GetObjectBucket(GetObjectResponse resultFinal = null, string errorFinal = null)
        {
            resultTextOperation.text = string.Format("fetching {0} from bucket {1}", fileNameOnBucket, S3BucketName);
            
            if(errorFinal != null)
            {
                resultTextOperation.text += "\n";
                resultTextOperation.text += "Get Data Error";
                print("Get Error:: " + errorFinal);
                return;
            }
            

            S3Manager.Instance.GetObjectBucket(S3BucketName, fileNameOnBucket, (result, error) =>
            {
                if (string.IsNullOrEmpty(error))
                {
                    resultTextOperation.text += "\nGet Data Complete.";
                }
                else
                {
                    resultTextOperation.text += "\n";
                    resultTextOperation.text += "Get Data Error";
                    print("Get Error:: " + error);
                }
            });

        }

        public void UploadObjectForBucket()
        {
            resultTextOperation.text = "Retrieving the file";
            resultTextOperation.text += "\nCreating request object";
            resultTextOperation.text += "\nMaking HTTP post call";
            string pathFile = Application.persistentDataPath+@"/"+UploadInputField.text;

            S3Manager.Instance.UploadObjectForBucket(pathFile, S3BucketName, fileNameOnBucket, (result, error) =>
            {
                if(string.IsNullOrEmpty(error))
                {
                    resultTextOperation.text += "\nUpload Success";
                }
                else
                {
                    resultTextOperation.text += "\nUpload Failed";
                    Debug.LogError("Get Error:: " + error);
                }
            });
        }

        public void DeleteObjectOnBucket()
        {
            resultTextOperation.text = string.Format("deleting {0} from bucket {1}\n", fileNameOnBucket, S3BucketName);

            S3Manager.Instance.DeleteObjectOnBucket(fileNameOnBucket, S3BucketName, (result, error) =>
            {
                if (string.IsNullOrEmpty(error))
                {
                    resultTextOperation.text += "\nFile Deleted Success";
                }
                else
                {
                    resultTextOperation.text += "\nFile Deleted Failed";
                    print("Get Error:: " + error);
                }
            });
        }
    }
}