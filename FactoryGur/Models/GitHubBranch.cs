using System.Text.Json.Serialization;

namespace FactoryGur.Models
{
    [Serializable]
    public class GitHubBranch 
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("commit")]
        public Commit? GitCommit { get; set; }

        [JsonPropertyName("protected")]
        public bool Protected { get; set; }
    }

    [Serializable]
    public class Commit {

        [JsonPropertyName("sha")]
        public string? Sha { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

    }
}