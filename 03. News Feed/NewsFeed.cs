using System.Text;
using System.Xml;

namespace NewsFeed
{
    public class NewsFeed
    {
        public NewsFeed(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Articles = new List<Article>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Article> Articles { get; set; }

        public void AddArticle(Article article)
        {
            int count = Articles
                .FindAll(a => a.Title == article.Title)
                .Count();

            if (count > 0)
            {
                return;
            }

            if (Articles.Count < Capacity)
            {
                Articles.Add(article);
            }
        }

        public bool DeleteArticle(string title)
        {
            int removedArticles = Articles.RemoveAll(a => a.Title == title);

            if (removedArticles > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Article GetShortestArticle()
        {
            Article article = Articles.MinBy(a => a.WordCount);

            return article;
        }

        public string GetArticleDetails(string title)
        {
            List<Article> articles = Articles
                .FindAll(a => a.Title == title);

            if (articles.Count == 1)
            {
                return articles.ElementAt(0).ToString().Trim();
            }
            else // count must have been 0
            {
                return $"Article with title '{title}' not found.".Trim();
            }
        }

        public int GetArticlesCount()
        {
            int count = Articles.Count;
            return count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} newsfeed content:".Trim());

            foreach (Article article in Articles.OrderBy(a => a.WordCount))
            {
                sb.AppendLine($"{article.Author}: {article.Title}".Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
