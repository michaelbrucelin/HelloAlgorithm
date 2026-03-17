using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现的并查集
    /// </summary>
    public class UnionFind_INT
    {
        /// <summary>
        /// 初始化并查集
        /// </summary>
        /// <param name="size"></param>
        public UnionFind_INT(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        private int[] parent;
        private int[] rank;

        /// <summary>
        /// 查找操作，带路径压缩
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Find(int p)
        {
            if (parent[p] != p) parent[p] = Find(parent[p]);  // 路径压缩

            return parent[p];
        }

        /// <summary>
        /// 查找操作，带路径压缩
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Find_Iteration(int p)
        {
            int f = p;
            while (parent[f] != f) f = parent[f];

            int i = p, j;
            while (parent[i] != f)
            {
                j = parent[i];
                parent[i] = f;
                i = j;
            }

            return parent[p];
        }

        /// <summary>
        /// 合并操作，按秩合并
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP != rootQ)
            {
                if (rank[rootP] != rank[rootQ])
                {
                    if (rank[rootP] > rank[rootQ]) parent[rootQ] = rootP; else parent[rootP] = rootQ;
                }
                else
                {
                    parent[rootQ] = rootP;
                    rank[rootP]++;
                }
            }
        }

        /// <summary>
        /// 检查两个元素是否属于同一集合
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }
    }
    /*
    public static void Main(string[] args)
    {
        int size = 10;
        UnionFind_INT uf = new UnionFind_INT(size);

        // 合并一些节点
        uf.Union(0, 1);
        uf.Union(1, 2);
        uf.Union(3, 4);
        uf.Union(4, 5);

        // 检查连接情况
        Console.WriteLine(uf.Connected(0, 2)); // True
        Console.WriteLine(uf.Connected(0, 3)); // False

        // 合并更多节点
        uf.Union(2, 3);

        // 再次检查连接情况
        Console.WriteLine(uf.Connected(0, 5)); // True
    }
    */
}
