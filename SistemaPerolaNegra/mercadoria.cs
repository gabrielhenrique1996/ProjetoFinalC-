using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPerolaNegra
{
    class mercadoria
    {
        string produto, categoria,tamanho;
        int quantidade;

        public string Produto { get => produto; set => produto = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Tamanho { get => tamanho; set => tamanho = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
    }
}
