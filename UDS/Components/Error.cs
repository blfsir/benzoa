using System;
using System.Diagnostics;
using System.IO;
using System.Web;
//add by 51aspx���޸���־д�����
namespace UDS.Components 
{
	/// <summary>
	/// �������������ڼ�¼������־
	/// </summary>
	public class Error {
		//��¼������־λ��

		/// <summary>
		/// ��¼��־���ı��ļ�
		/// </summary>
		/// <param name="message">��¼������</param>
		public static void Log(string message) {

		string FILE_NAME = HttpContext.Current.Server.MapPath("/51aspxlog.txt").ToString();
			if(File.Exists(FILE_NAME))
			{
				StreamWriter sr = File.AppendText(FILE_NAME);
				sr.WriteLine ("\n");
				sr.WriteLine (DateTime.Now.ToString()+message);
				sr.Close();
			}
			else
			{
				StreamWriter sr = File.CreateText(FILE_NAME);
				sr.Close();
			}
			
				
		}
	}
}
