using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcesso
{
    internal class Ambiente
    {
        public int id;
        public string nome;
        public Queue<Log> logs;

        public Ambiente(int id)
        {
            this.id = id;
        }

        public Ambiente()
        {
        }

        public Ambiente(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public void registrarLog(Log log)
        {

        }

        public override string ToString()
        {
            return "   - " + nome;
        }

    }
}
