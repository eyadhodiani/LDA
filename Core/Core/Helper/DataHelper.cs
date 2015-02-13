using Core.Data;
using Core.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class DataHelper
    {
        private static string clearSuffixes(string word)
        {
            //if (word == "منتخب")
            //{
            //    string m = "";
            //}
            if (word.Length < 2)
                return "";

            List<string> Suffixes = new List<string> { "ون", "ين", "ان", "ت", "تم", "تما", "تن", "تا", "تمو",  "ي", "نا", "وا", "ك", "كم", "كما", "كن", "ه", "ها", "هما", "هم", "هن", "نا", "ات" };
            
            var aa = Suffixes.ToArray().OrderByDescending(aux => aux.Length).ToArray();

            foreach (var item in aa)
            {
                if (word.Length > item.Length)
                {
                    if (word.Substring(word.Length - item.Length, item.Length) == item)
                    {
                        word = word.Substring(0, word.Length - item.Length ) + word.Substring(word.Length - item.Length, item.Length).Replace(item, "");
                        break;
                    }
                }
            }
            //

            return word;
        }
        private static string clearPrefix(string word)
        {
            //if (word == "المنتخب")
            //{
            //    string m = "";
            //}

            if (word.Length < 2)
                return "";


            List<string> Prefix = new List<string> { "ولل", "وال", "ال", "لل", "ول", "فلل", "وب", "فب", "أب", "لب", "فل", "أل", "وك", "فك", "أك", "لك", "فو", "بال", "وبال", "فبال", "أبال", "وكال", "فكال", "أكال", "لكال", "وس", "فس", "أس", "است" };
            var aa = Prefix.ToArray().OrderByDescending(aux => aux.Length).ToArray();

            foreach (var item in aa)
            {
                if (word.Length > item.Length)
                {
                    if (word.Substring(0, item.Length) == item)
                    {
                        word = word.Substring(0, item.Length).Replace(item, "") + word.Substring(item.Length, word.Length - item.Length);
                        break;
                    }
                }
            }
            //

            return word;
        }
        public static void LoadCorpus(this Parameter parameter, params char[] delimiter)
        {
            //parameter.CorpusPath = @"C:\docs1\4ff550e2-a07e-43b9-bd4a-e776c30b60dc_35.txt";
            DataAccess cls = new DataAccess();
            string sql = "select * from [stopword]";
            DataSet ds = new DataSet();
            string m = cls.getData(sql, ref ds);
            DataTable stop_words = ds.Tables[0];

            string[] replace = { ",", "|", ">", "<", "?", ";", ".", ")", "(", "\"", "*", "&", "%", "$", "#", "@", "!", "»", "«", "،", "،", ":", "/", "١", "٠", "٢", "٧", "٥", "٨", "٣", "٤" };
            int counter = 1;
            int counter_words = 1;


            Console.WriteLine(parameter.CorpusPath);

            sql = "delete from roots ";
            m = cls.exeQuery(sql);

            if (parameter.CorpusPath.Contains(".txt"))
            {
                Console.WriteLine(parameter.CorpusPath);
                var file = parameter.CorpusPath;
                string contents = File.ReadAllText(file);
                string filenameWithoutPath = Path.GetFileName(file.ToString());
                //sql = "insert into document (id,doc_name) values(" + counter + ", N'" + filenameWithoutPath + "')";
                //m = cls.exeQuery(sql);


                string new_contents = "";
                for (int i = 0; i < replace.Length; i++)
                {
                    contents = contents.Replace(replace[i], " ");
                }

              
                foreach (var word in contents.ToLower().Split(delimiter))
                {
                    if (word.Length >= 3)
                    {


                        var query = from a in ds.Tables[0].AsEnumerable()
                                    where a.Field<string>("word").Trim() == word.Trim()
                                    select a;
                        bool found = false;
                        foreach (var item in query)
                        {
                            found = true;
                        }

                        if (found == false)
                        {
                            string  token = clearPrefix(word);
                            if (token.Length < 3)
                            {
                                continue;
                            }

                            token = clearSuffixes(token);
                            if (token.Length < 3)
                            {
                                continue;
                            }
                            new_contents += token + " ";

                            sql = "insert into roots (root,word) values(  N'" + token + "', N'" + word + "')";
                            m = cls.exeQuery(sql);
                            //counter_words += 1;
                        }


                    }
                }
                var document = new Document("TEST", new_contents);
                

                parameter.DocumentList.Add(document);
            }
            else
            {
                foreach (string file in Directory.EnumerateFiles(parameter.CorpusPath, "*.txt"))
                {
                    string contents = File.ReadAllText(file);
                    string filenameWithoutPath = Path.GetFileName(file.ToString());
                    //sql = "insert into document (id,doc_name) values(" + counter + ", N'" + filenameWithoutPath + "')";
                    //m = cls.exeQuery(sql);


                    string new_contents = "";
                    for (int i = 0; i < replace.Length; i++)
                    {
                        contents = contents.Replace(replace[i], " ");
                    }
                    foreach (var word in contents.ToLower().Split(delimiter))
                    {
                        if (word.Length >= 3)
                        {


                            var query = from a in ds.Tables[0].AsEnumerable()
                                        where a.Field<string>("word").Trim() == word.Trim()
                                        select a;
                            bool found = false;
                            foreach (var item in query)
                            {
                                found = true;
                            }

                            if (found == false)
                            {

                                string token = clearPrefix(word);
                                if (token.Length < 3)
                                {
                                    continue;
                                }

                                token = clearSuffixes(token);
                                if (token.Length < 3)
                                {
                                    continue;
                                }
                                new_contents += token + " ";

                                sql = "insert into roots (root,word) values(  N'" + token + "', N'" + word + "')";
                                m = cls.exeQuery(sql);
                            }


                        }
                    }
                    var document = new Document("TEST", new_contents);
                    if (document.Count == 0) continue;

                    counter += 1;

                    parameter.DocumentList.Add(document);

                    //counter += 1;
                    //if (counter == 100)
                    //    break;



                }
            }
            //return;
            //var corpus = File.ReadAllLines(parameter.CorpusPath, Encoding.Default).Skip(1);
            //foreach (var rawData in corpus)
            //{
            //    var document = new Document("TEST", rawData);
            //    if (document.Count == 0) continue;

            //    parameter.DocumentList.Add(document);
            //}

            //--------------------------------------------------------

            //--------------------------------------------------------
        }
    }
}
