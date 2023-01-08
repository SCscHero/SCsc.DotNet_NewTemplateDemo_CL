using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SCsc_DesignPattern.Composite
{
    public class Recursion
    {
        /// <summary>
        /// 根据节点路径寻找，递归
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>fatkun
        public static List<DirectoryInfo> GetDirectoryList(string rootPath)
        {
            List<DirectoryInfo> dirList = new List<DirectoryInfo>();
            DirectoryInfo dirRoot = new DirectoryInfo(rootPath);//根目录
            dirList.Add(dirRoot);
            GetDirectoryListChild(dirList, dirRoot);
            return dirList;
        }


        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="dirList">结果容器</param>
        /// <param name="dirParent">当前文件夹</param>
        private static void GetDirectoryListChild(List<DirectoryInfo> dirList, DirectoryInfo dirParent)
        {
            DirectoryInfo[] dirListChild = dirParent.GetDirectories();
            dirList.AddRange(dirListChild);
            foreach (var item in dirListChild)
            {
                GetDirectoryListChild(dirList, item);
            }

        }

    }
}
