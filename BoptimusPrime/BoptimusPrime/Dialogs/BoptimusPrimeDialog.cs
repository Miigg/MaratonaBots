using BoptimusPrime.Forms;
using BoptimusPrime.Services;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BoptimusPrime.Dialogs
{
    [Serializable]
    public class BoptimusPrimeDialog : BaseLuisDialog<object>
    {
        string qnaSubscriptionKey = ConfigurationManager.AppSettings["QnaSubscriptionKey"];
        string qnaKnowledgebaseId = ConfigurationManager.AppSettings["QnaKnowledgebaseId"];
        [NonSerialized]
        IMessageActivity messageActivity;

        public BoptimusPrimeDialog(IMessageActivity messageActivity)
        {
            this.messageActivity = messageActivity;
        }

        [LuisIntent("Cumprimento")]
        public async Task Cumprimento(IDialogContext context, LuisResult result)
        {
            var qnaService = new QnAMakerService(new QnAMakerAttribute(qnaSubscriptionKey, qnaKnowledgebaseId, "eh o que maluco ?  ¯＼(º_o)/¯"));
            var qnaMaker = new QnAMakerDialog(qnaService);
            await qnaMaker.MessageReceivedAsync(context, Awaitable.FromItem(messageActivity));
        }

        [LuisIntent("Sugestao")]
        public async Task Sugestao(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("voce descobriu o EasterEgg parabens!");   
        }

        [LuisIntent("SugestaoCategoria")]
        public async Task SugestaoCategoria(IDialogContext context, LuisResult result)
        {
            FormDialog<CategoriaForm> sugestaoForm = new FormDialog<CategoriaForm>(new CategoriaForm(), CategoriaForm.BuildForm, FormOptions.PromptInStart);
            context.Call(sugestaoForm, CategoriaFormCompleteAsync);
        }
      
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"nao intidi o que o ce falo : {result.Query}");
        }
  
        private async Task CategoriaFormCompleteAsync(IDialogContext context, IAwaitable<CategoriaForm> result)
        {
            var categoriaForm = await result;
            var movieService = new BoptimusService();
            await movieService.ConfigureAuthentication();
            var genreList = await movieService.GetMedias((int)categoriaForm.Categoria);

            var msg = context.MakeMessage();
            msg.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            foreach (var media in genreList)
            {
                var card = new CardPersonalizedService().CreateCard(media);
                msg.Attachments.Add(card.ToAttachment());
            }
            await context.PostAsync(msg);

        }
        public HeroCard CreateCard()
        {
            var heroCard = new HeroCard
            {
                Title = "Baseado no que ?",
                Subtitle = "",
                Buttons = new List<CardAction>
                {
                   new CardAction
                    {
                        Text = "Baseado em uma Categoria",
                        DisplayText = "Baseado em uma Categoria",
                        Title = "Baseado em uma Categoria",
                        Type = ActionTypes.PostBack,
                        Value = $"Categoria"

                    }

                }
            };

            return heroCard;
        }
    }

}