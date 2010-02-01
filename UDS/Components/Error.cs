using System;
using System.Diagnostics;
using System.IO;
using System.Web;
//add by 51aspx，修改日志写入错误
namespace UDS.Components 
{
	/// <summary>
	/// 错误处理函数，用于记录错误日志
	/// </summary>
	public class Error {
		//记录错误日志位置

		/// <summary>
		/// 记录日志至文本文件
		/// </summary>
		/// <param name="message">记录的内容</param>
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
