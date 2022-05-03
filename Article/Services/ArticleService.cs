using System.ComponentModel.DataAnnotations;
using AspireOverflow.DataAccessLayer;
using AspireOverflow.Models;

using AspireOverflow.DataAccessLayer.Interfaces;




namespace AspireOverflow.Services
{

    public class ArticleService
    {
        private static IArticleRepository database;

        private static ILogger<ArticleService> _logger;

         public ArticleService(ILogger<ArticleService> logger)
        {
            _logger = logger ?? throw new NullReferenceException("logger can't be null");
            database = ArticleRepositoryFactory.GetArticleRepositoryObject(logger);

        }

         public bool CreateArticle(Article article, Enum DevelopmentTeam)
        {
            if (!Validation.ValidateArticle(article)) throw new ValidationException("Given data is InValid");
            try
            {
                return database.AddArticle(article);

            }

            catch (Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage(DevelopmentTeam, nameof(CreateArticle), exception, article));
                return false;
            }
        }

         public bool AddCommentToArticle(ArticleComment comment, Enum DevelopmentTeam)
        {
            Validation.ValidateArticleComment(comment);
            try
            {
                return database.AddComment(comment);
            }
            catch (Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage(DevelopmentTeam, nameof(AddCommentToArticle), exception), comment);
                return false;
            }
        }

        public Article GetArticle(int ArticleId, Enum DevelopmentTeam)
        {
            Validation.ValidateId(ArticleId);
            try
            {
                return database.GetArticleByID(ArticleId);
            }
            catch (Exception exception)
            {

                _logger.LogError(HelperService.LoggerMessage(DevelopmentTeam, nameof(GetArticle), exception, ArticleId));

                throw exception;
            }

        }

        public bool DeleteArticleByArticleIdAndArticleStatusID(int ArticleId,int VerifyStatusID, Enum DevelopmentTeam)
        {
            Validation.ValidateId(ArticleId,VerifyStatusID);
            try
            {
                return database.UpdateArticle(ArticleId, VerifyStatusID );
            }
            catch (Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage(DevelopmentTeam, nameof(DeleteArticleByArticleIdAndArticleStatusID), exception), ArticleId);

                throw exception;
            }

        }




        



    }
}