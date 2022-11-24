using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcesso
{
    internal class Usuario
    {

        public int id;
        public string nome;
        public List<Ambiente> ambientes = new List<Ambiente>();

        public Usuario(int id) : this(id, "")
        { }
        public Usuario() : this(0, "")
        {

        }
        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }


        public bool concederPermissao(Ambiente ambiente)
        {
            
            foreach(Ambiente amb in ambientes)
            {
                if (ambiente.id == amb.id)
                {
                    return false;
                }
                else
                {
                   
                }
            }
            ambientes.Add(ambiente);
            return true; 

        }

        public bool revogarPermissao(Ambiente ambiente)
        {
            return false;
        }


        public override string ToString()
        {
            return "Id: " + id +
                   "\nNome: " + nome;
        }



    }
}
