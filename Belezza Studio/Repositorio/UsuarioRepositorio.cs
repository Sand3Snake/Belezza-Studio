using Belezza_Studio.Models;
using Belezza_Studio.ORM;

namespace Belezza_Studio.Repositorio
{
    public class UsuarioRepositorio
    {
        public readonly BdBelezzaStudioContext _context;

        public UsuarioRepositorio(BdBelezzaStudioContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {            
            // Cria uma nova entidade do tipo TbUsuario a partir do objeto Atendimento recebido
            var tbUsuario = new TbUsuario()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Senha = usuario.Senha,
                TipoUsuario = usuario.TipoUsuario,
            };

            // Adiciona a entidade ao contexto
            _context.TbUsuarios.Add(tbUsuario);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbUsuario = _context.TbUsuarios.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbUsuario != null)
            {
                // Remove a entidade do contexto
                _context.TbUsuarios.Remove(tbUsuario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario não encontrado.");
            }
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> listFun = new List<Usuario>();

            var listTb = _context.TbUsuarios.ToList();

            foreach (var item in listTb)
            {
                var usuario = new Usuario
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    Senha = item.Senha,
                    TipoUsuario = item.TipoUsuario,
                };

                listFun.Add(usuario);
            }

            return listFun;
        }

        public Usuario GetById(int id)
        {
            // Busca o usuario pelo ID no banco de dados
            var item = _context.TbUsuarios.FirstOrDefault(f => f.Id == id);

            // Verifica se o usuario foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Usuario
            var usuario = new Usuario
            {
                Id = item.Id,
                Nome = item.Nome,
                Email = item.Email,
                Telefone= item.Telefone,
                Senha = item.Senha,
                TipoUsuario= item.TipoUsuario,
            };

            return usuario; // Retorna o usuario encontrado
        }

        public void Update(Usuario usuario, IFormFile foto)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbUsuario = _context.TbUsuarios.FirstOrDefault(f => f.Id == usuario.Id);

            // Verifica se a entidade foi encontrada
            if (tbUsuario != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Usuario recebido
                tbUsuario.Id = usuario.Id;
                tbUsuario.Nome = usuario.Nome;
                tbUsuario.Email = usuario.Email;
                tbUsuario.Telefone = usuario.Telefone;
                tbUsuario.Senha = usuario.Senha;
                tbUsuario.TipoUsuario = usuario.TipoUsuario;


                // Atualiza as informações no contexto
                _context.TbUsuarios.Update(tbUsuario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario não encontrado.");
            }
        }
    }

}
