using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileControll
{
    public sealed class FileControll
    {
        /// <summary>
        /// リトライ回数
        /// </summary>
        private const int RETRYCOUNT = 3;

        /// <summary>
        /// ファイル移動
        /// </summary>
        /// <param name="from">移動対象</param>
        /// <param name="to">移動先</param>
        /// <param name="outException">エラーを返す/返さない</param>
        public static void Move(string from, string to, bool outException = true)
        {
            try
            {
                // ファイル移動
                File.Move(from, to);
            }
            catch (Exception e)
            {
                // ファイル移動を再実行
                Move(from, to, 0);
                if (outException) throw e;
            }
        }

        /// <summary>
        /// ファイル移動再実行
        /// </summary>
        /// <param name="from">移動対象</param>
        /// <param name="to">移動先</param>
        /// <param name="retryCount">再実行回数</param>
        public static void Move(string from, string to, int retryCount)
        {
            try
            {
                // ファイル移動を再実行
                File.Move(from, to);
            }
            catch
            {
                // 再実行回数がリトライ回数以下なら、ファイル移動を再実行
                retryCount++;
                if (retryCount <= RETRYCOUNT) Move(from, to, 0);
            }
        }

        /// <summary>
        /// ファイルコピー
        /// </summary>
        /// <param name="from">コピー元</param>
        /// <param name="to">コピー先</param>
        /// <param name="outException">エラーを返す/返さない</param>
        public static void Copy(string from, string to, bool outException = true)
        {
            try
            {
                // ファイルコピー
                File.Copy(from, to);
            }
            catch (Exception e)
            {
                // ファイルコピーを再実行
                Copy(from, to, 0);
                if (outException) throw e;
            }
        }

        /// <summary>
        /// ファイルコピー再実行
        /// </summary>
        /// <param name="from">コピー元</param>
        /// <param name="to">コピー先</param>
        /// <param name="retryCount">再実行回数</param>
        public static void Copy(string from, string to, int retryCount)
        {
            try
            {
                // ファイルコピーを再実行
                File.Copy(from, to);
            }
            catch
            {
                // 再実行回数がリトライ回数以下なら、ファイルコピーを再実行
                retryCount++;
                if (retryCount <= RETRYCOUNT) Copy(from, to, retryCount);
            }
        }

        /// <summary>
        /// ファイル削除
        /// </summary>
        /// <param name="from">削除先</param>
        /// <param name="deleteAll">全削除判定</param>
        /// <param name="outException">エラーを返す/返さない</param>
        public static void Delete(string from, bool deleteAll = false, bool outException = true)
        {
            try
            {
                // ファイル削除
                Directory.Delete(from, deleteAll);
            }
            catch (Exception e)
            {
                // ファイル削除を再実行
                Delete(from, deleteAll, 0);
                if (outException) throw e;
            }
        }

        /// <summary>
        /// ファイル削除を再実行
        /// </summary>
        /// <param name="from">削除先</param>
        /// <param name="deleteAll">全削除先</param>
        /// <param name="retryCount">再実行回数</param>
        public static void Delete(string from, bool deleteAll, int retryCount)
        {
            try
            {
                // ファイル削除を再実行
                Directory.Delete(from, deleteAll);
            }
            catch
            {
                // 再実行回数がリトライ回数以下なら、ファイルコピーを再実行
                retryCount++;
                if (retryCount <= RETRYCOUNT) Delete(from, deleteAll, retryCount);
            }
        }
    }
}
