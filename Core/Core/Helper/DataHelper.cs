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
        public static void LoadCorpus(this Parameter parameter, params char[] delimiter)
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from [stopword]";
            DataSet ds = new DataSet();
            string m = cls.getData(sql, ref ds);
            DataTable stop_words = ds.Tables[0];

            string[] replace = { ",", "|", ">", "<", "?", ";", ".", ")", "(", "\"", "*", "&", "%", "$", "#", "@", "!", "»", "«", "،", "،", ":", "/", "١", "٠", "٢", "٧", "٥", "٨", "٣", "٤" };
            int counter = 1;
            int counter_words = 1;


            Console.WriteLine(parameter.CorpusPath);

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

                            new_contents += word + " ";

                            //sql = "insert into doc_words (id,doc_id,word) values(" + counter_words + "," + counter + ", N'" + word + "')";
                            //m = cls.exeQuery(sql);
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

                                new_contents += word + " ";

                                //sql = "insert into doc_words (id,doc_id,word) values(" + counter_words + "," + counter + ", N'" + word + "')";
                                //m = cls.exeQuery(sql);
                                //counter_words += 1;
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
