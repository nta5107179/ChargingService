using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using CoreClass;
using System.Configuration;
using ServiceStack.Redis;

namespace SystemFramework
{
	/// <summary>
	/// 公共方法库
	/// </summary>
	public class Factory
	{
		/// <summary>
		/// 字符串操作
		/// </summary>
		public OperateStringClass OpString = new OperateStringClass();
		/// <summary>
		/// 数据集操作
		/// </summary>
		public OperateDataClass OpData = new OperateDataClass();
		/// <summary>
		/// 功能操作
		/// </summary>
		public OperateMemoryClass OpMemory = new OperateMemoryClass();
		/// <summary>
		/// 文件操作
		/// </summary>
		public OperateFileClass OpFile = new OperateFileClass();
		/// <summary>
		/// 数组操作
		/// </summary>
        public OperateArrayClass OpArray = new OperateArrayClass();
		/// <summary>
		/// 数据库操作
		/// </summary>
        protected OperateSqlClass OpSql = new OperateSqlClass();
        /// <summary>
        /// 远程缓存操作
        /// </summary>
        public OperateRedisClass OpRedis = new OperateRedisClass();

		/// <summary>
		/// 初始化Factory类型的新实例
		/// </summary>
		public Factory()
		{

		}
		
	}
}