namespace CrudProdutosConsole;

public class ProdutoRepository
{
    
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CrudProdutosConsole
{
    public class ProdutoRepository
    {
        private readonly string _path;
        private List<Produto> _produtos;

        public ProdutoRepository(string filePath = "data/products.json")
        {
            _path = filePath;
            var dir = Path.GetDirectoryName(_path) ?? "data";
            Directory.CreateDirectory(dir);
            _produtos = Load();
        }

        private List<Produto> Load()
        {
            if (!File.Exists(_path)) return new List<Produto>();
            var json = File.ReadAllText(_path);
            if (string.IsNullOrWhiteSpace(json)) return new List<Produto>();
            try
            {
                return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
            }
            catch
            {
                return new List<Produto>();
            }
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_produtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public List<Produto> GetAll() => _produtos.ToList();

        public Produto? Get(int id) => _produtos.FirstOrDefault(p => p.Id == id);

        public void Add(Produto p)
        {
            var nextId = _produtos.Count == 0 ? 1 : _produtos.Max(x => x.Id) + 1;
            p.Id = nextId;
            _produtos.Add(p);
            Save();
        }

        public bool Update(Produto p)
        {
            var idx = _produtos.FindIndex(x => x.Id == p.Id);
            if (idx < 0) return false;
            _produtos[idx] = p;
            Save();
            return true;
        }

        public bool Delete(int id)
        {
            var removed = _produtos.RemoveAll(x => x.Id == id) > 0;
            if (removed) Save();
            return removed;
        }
    }
}
