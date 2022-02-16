using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server_Project
{
   


    internal class Server
    {
        
        List<string> smsg = new List<string>();
        Dictionary<string, long> ctlist1 = new Dictionary<string, long>();
        List<string> grpmem = new List<string>();










        public void Sendc1()//client 1 sending msg to server
        {
            Console.WriteLine("enter msg to client 2.... : ");
           string msg=Console.ReadLine();
            smsg.Add(msg);



        }
        public void sendc2()//client 2 sending msg to server
        {
            Console.WriteLine("enter msg to client 1.... : ");
            string msg = Console.ReadLine();
            smsg.Add(msg);

        }
        public void dplay()//displaying chat history
        {
            Console.WriteLine("chat history of client 1 and client 2 : ");
            foreach (string s in smsg)
            {
                Console.WriteLine(s);
                

            }
            string k = smsg[0];
            string v = smsg[1];
            Console.WriteLine("msg frm client 1 "+ k);
            Console.WriteLine("msg frm client 2 "+v);   
            Console.Read();

        }
        
        public void Cnt_list()//user defined contact list
        {
            int i = 1;
            Console.WriteLine("enter the how many number of contacts you need to add: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            

            while (i <= n1)
            {
                Console.WriteLine("enter the {0} name of the contact: ",i);
                string name = Console.ReadLine();
                Console.WriteLine("enter the {0} number of the contact: ",i);
                long number = long.Parse(Console.ReadLine());
                ctlist1.Add(name,number);
                i++;
            }
            Console.WriteLine("**Contact list** ");//storing same contacts in files
            foreach (KeyValuePair<string, long> d in ctlist1)
            {
                Console.WriteLine(d);
            }
            FileInfo fn = new FileInfo(@"F:\PhoneBook.txt");
            if (fn.Exists)
            {


                using (StreamWriter swr = fn.AppendText())
                {
                    swr.WriteLine("**Contact list** ");

                    foreach (KeyValuePair<string, long> d in ctlist1)
                    {
                        swr.WriteLine(d);
                    }
                }
            }

        }
        public void addmemgrp()//adding contact members in group
        {
            int i = 1;
            Console.WriteLine("enter the how many number of contacts you need to add: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            while (i <= n1)
            {
                Console.WriteLine("enter the name of {0} member: ",i);
                string name = Console.ReadLine();
                if (!ctlist1.ContainsKey(name))
                {
                    Console.WriteLine("The {0} name is not register please register", i);
                    Cnt_list();
                }
                else
                {
                    grpmem.Add(name);


                }
                i++;

            }
            Console.WriteLine(" displaying all the group members you ware added");
            foreach (string name in grpmem)
            {
                Console.WriteLine(name);
            }
            Console.Read ();
            Console.WriteLine("if you want to remove a member press\"1\" else press any ket to continue");
            string num1 = Console.ReadLine();

            if (num1 == "1")//removing members in group
            {
                

                string name_r = Console.ReadLine();

                grpmem.Remove(name_r);
                foreach (string n in grpmem)
                {
                    Console.WriteLine(n);
                    Console.Read();
                }
               




            }




        }
       
        


    }
}
