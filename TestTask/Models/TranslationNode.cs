using System.Collections.Generic;
using System.Linq;

namespace TestTask.Models
{
    class TranslationNode
    {
        public List<TranslationNode> Children { get; }
        public Dictionary<string, string> Translations { get; }
        public string Name { get; }

        public TranslationNode(string name)
        {
            Children = new List<TranslationNode>();
            Translations = new Dictionary<string, string>();

            Name = name;
        }

        public void AddChild(TranslationNode child)
        {
            Children.Add(child);
        }

        public void AddTranslation(string id, string str)
        {
            Translations.Add(id, str);
        }

        public TranslationNode GetChild(string name)
        {
            return Children.FirstOrDefault(c => c.Name == name);
        }
    }
}
