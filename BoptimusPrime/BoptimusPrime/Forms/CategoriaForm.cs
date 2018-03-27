using Microsoft.Bot.Builder.FormFlow;
using System;

namespace BoptimusPrime.Forms
{
    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "Desculpe não entendi \"{0}\".")]
    public class CategoriaForm
    {
        public Categoria Categoria { get; set; }

        public static IForm<CategoriaForm> BuildForm()
        {
            var form = new FormBuilder<CategoriaForm>();
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            form.Configuration.Yes = new string[] { "sim", "yes", "s", "y", "yep" };
            form.Configuration.No = new string[] { "não", "nao", "no", "not", "n" };
            return form.Build();
        }

    }


    [Describe("Categoria")]
    public enum Categoria
    {

        [Terms("comedia", "risada", "huehuebr", "rir", "kkkkkk", "Engracado")]
        [Describe("Comedia")]
        Comedia = 35,

        [Terms("drama", "tensao", "apreensao")]
        [Describe("Drama")]
        Drama = 18,

        [Terms("acao", "lutinha", "luta", "tapa", "soco", "porrada", "tiro", "bomba", "carro", "corrida", "Ação")]
        [Describe("Ação")]
        Acao = 28,

        [Terms("Ficcao", "historinha", "Ficção", "Ficção cientifica", "mentirinha", "super heroi", "monstro", "tubarao voador", "tubarao na neve", "Dinofauro", "Dinossauro", "viagem no tempo", "desastres naturais", "Ficção científica")]
        [Describe("Ficção cientifica")]
        FiccaoCientifica = 878,

        [Terms("romance", "love", "amor", "10/10", "crush", "melo dramatico", "melacao", "beijo", "amorzinho", "t grande")]
        [Describe("Romance")]
        Romance = 10749,

        [Describe("Aventura")]
        Aventura = 12,

        [Describe("Animação")]
        Animacao = 16,

        [Describe("Crime")]
        Crime = 80,

        [Describe("Documentário")]
        Documentario = 99,

        [Describe("Família")]
        Familia = 10751,

        [Describe("Fantasia")]
        Fantasia = 14,

        [Describe("História")]
        Historia = 36,

        [Describe("Terror")]
        Terror = 27,

        [Describe("Música")]
        Musica = 10402,

        [Describe("Mistério")]
        Misterio = 9648,

        [Describe("Cinema TV")]
        CinemaTV = 10770,

        [Describe("Thriller")]
        Thriller = 53,

        [Describe("Guerra")]
        Guerra = 10752,

        [Describe("Faroeste")]
        Faroeste = 37,

        [Describe("Tanto Faz")]
        TantoFaz = 98754321

    }
}

