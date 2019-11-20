﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var searchResult = SearchResult.FromJson(jsonString);

namespace Search
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SearchResult
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("status")]
        public long Status { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("hits")]
        public Hit[] Hits { get; set; }
    }

    public partial class Hit
    {
        [JsonProperty("highlights")]
        public object[] Highlights { get; set; }

        [JsonProperty("index")]
        public Index Index { get; set; }

        [JsonProperty("type")]
        public Index Type { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("annotation_count")]
        public long AnnotationCount { get; set; }

        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("full_title")]
        public string FullTitle { get; set; }

        [JsonProperty("header_image_thumbnail_url")]
        public Uri HeaderImageThumbnailUrl { get; set; }

        [JsonProperty("header_image_url")]
        public Uri HeaderImageUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("lyrics_owner_id")]
        public long LyricsOwnerId { get; set; }

        [JsonProperty("lyrics_state")]
        public LyricsState LyricsState { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("pyongs_count")]
        public long? PyongsCount { get; set; }

        [JsonProperty("song_art_image_thumbnail_url")]
        public Uri SongArtImageThumbnailUrl { get; set; }

        [JsonProperty("song_art_image_url")]
        public Uri SongArtImageUrl { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("title_with_featured")]
        public Title TitleWithFeatured { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("primary_artist")]
        public PrimaryArtist PrimaryArtist { get; set; }
    }

    public partial class PrimaryArtist
    {
        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("header_image_url")]
        public Uri HeaderImageUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("is_meme_verified")]
        public bool IsMemeVerified { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("iq", NullValueHandling = NullValueHandling.Ignore)]
        public long? Iq { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("unreviewed_annotations")]
        public long UnreviewedAnnotations { get; set; }

        [JsonProperty("hot")]
        public bool Hot { get; set; }

        [JsonProperty("pageviews", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pageviews { get; set; }
    }

    public enum Index { Song };

    public enum LyricsState { Complete };

    public enum Title { StormyWeather };

    public partial class SearchResult
    {
        public static SearchResult FromJson(string json) => JsonConvert.DeserializeObject<SearchResult>(json, Search.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SearchResult self) => JsonConvert.SerializeObject(self, Search.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                IndexConverter.Singleton,
                LyricsStateConverter.Singleton,
                TitleConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class IndexConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Index) || t == typeof(Index?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "song")
            {
                return Index.Song;
            }
            throw new Exception("Cannot unmarshal type Index");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Index)untypedValue;
            if (value == Index.Song)
            {
                serializer.Serialize(writer, "song");
                return;
            }
            throw new Exception("Cannot marshal type Index");
        }

        public static readonly IndexConverter Singleton = new IndexConverter();
    }

    internal class LyricsStateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LyricsState) || t == typeof(LyricsState?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "complete")
            {
                return LyricsState.Complete;
            }
            throw new Exception("Cannot unmarshal type LyricsState");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LyricsState)untypedValue;
            if (value == LyricsState.Complete)
            {
                serializer.Serialize(writer, "complete");
                return;
            }
            throw new Exception("Cannot marshal type LyricsState");
        }

        public static readonly LyricsStateConverter Singleton = new LyricsStateConverter();
    }

    internal class TitleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Title) || t == typeof(Title?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return Title.StormyWeather;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Title)untypedValue;
            if (value == Title.StormyWeather)
            {
                serializer.Serialize(writer, "Stormy Weather");
                return;
            }
            throw new Exception("Cannot marshal type Title");
        }

        public static readonly TitleConverter Singleton = new TitleConverter();
    }
}
