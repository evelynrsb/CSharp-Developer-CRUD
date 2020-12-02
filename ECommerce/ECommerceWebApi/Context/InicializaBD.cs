using ECommerceWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceWebApi.Context
{
    public class InicializaBD
    {
        public static void Initialize(ECommerceContext context)
        {
            context.Database.EnsureCreated();

            PopularDepartamentos(context);
            PopularProdutos(context);
                        
            context.SaveChanges();
        }

        private static async void PopularDepartamentos(ECommerceContext context)
        {
            if (context.Departamentos.Any())
            {
                return;
            }

            HttpClient client = new HttpClient(); ;
            System.Net.Http.HttpResponseMessage response = client.GetAsync("https://private-anon-06ed7100f1-maximatech.apiary-mock.com/fullstack/departamento").Result;
            if (response.IsSuccessStatusCode)
            {
                var departamentoJsonString = await response.Content.ReadAsStringAsync();
                List<Departamento> departamentos = JsonConvert.DeserializeObject<List<Departamento>>(departamentoJsonString).ToList();
                foreach (Departamento dep in departamentos)
                {
                    context.Departamentos.Add(dep);
                }
            }

        }

        private static void PopularProdutos(ECommerceContext context)
        {
            // Procura por produtos
            if (context.Produtos.Any())
            {
                return;   //O BD foi alimentado
            }
            Produto produto1 = new Produto(1, 14984, "Pneu Firestone - 68 x 22 x 68 cm; 13 Quilogramas", 600M, true, 3);
            context.Produtos.Add(produto1);
            Produto produto2 = new Produto(2, 15310, "Composto Lacteo Milnutri Premium Danone Nutricia 400g", 19.89M, true, 4);
            context.Produtos.Add(produto2);
            Produto produto3 = new Produto(3, 21556, "Xaiomi Redmi Note 9 128gb 4gb RAM - Versão Global - Midnight Grey", 1499M, false, 8);
            context.Produtos.Add(produto3);

        }


    }
}
