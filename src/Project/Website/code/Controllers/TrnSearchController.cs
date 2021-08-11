using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Coforge.Project.Website.Models;
//SEARCH namespace
using Sitecore.ContentSearch; //ContentSearch
using Sitecore.ContentSearch.SearchTypes; //SearchResultItem

namespace Coforge.Project.Website.Controllers
{
    public class TrnSearchController : Controller
    {
        //=====
        // GET: TrnSearch
        //=====
        [HttpGet]
        public ActionResult Index()
        { 
            //output to get SearchForm
            return View();
        }


        //=====
        //POST : TrnSearch
        //=====
        //we need to pass SearchTerm Model & Object for new View here
        [HttpPost]
        public ActionResult Index(SearchViewModel searchViewModelInput)
        {
            //_____________________
            //SEARCH IMPLEMENTATION
            //=====================
            //1.GET The value from the searchText

            //2.CONNECT to your Index
            //------------------------
            //ContentSearchManager - connecting content with solr
            //Sitecore.ContentSearch (solr index: cfg_web_index)
            //ContentSearch Mangaer
            //  - replaces 'cfg'_web_index with 'sitecore'_web_index
            //  - Connects our code with this index(solr)                    
            //creates index - contentSearchObject
            ISearchIndex index = ContentSearchManager.GetIndex("sitecore_web_index");

            //SEARCH RESULTS (List) 
            //---------------------
            //Result of type - SearchResultItem class
            //Sitecore.ContentSearch.SearchTypes
            List<SearchResultItem> result;

            //3.CREATE a querycontext & SEARCH on that query Context
            //-------------------------------------------------------
            //Search inside this context only & close after search - using block()
            //index.CreateSearchContext() - creating a context
            //context = queryContext - search on this context
            using(IProviderSearchContext context = index.CreateSearchContext())
            {
                //DO the SEARCH on queyContext (context)
                //--------------------------------------
                //GetQuerable<> - generic(query any data with this) 
                //Sitecore.ContentSearch.SearchTypes
                //SearchResultItem.content - exposes the fields in the content
                //Where => Search on which template
                //Wherer => SearchTerm = searchOn which term (SearchTerm - InputParameter used as object here)
                result = context?.GetQueryable<SearchResultItem>()
                                     .Where(x => x.TemplateName == "TrnArticle")
                                     .Where(x => x.Content.Contains(searchViewModelInput.Term.SearchText))
                                     .ToList();
            }

            //4.TRANSFORM the result to send to View(tite,description)
            //---------------------------------------
            //SearchViewModel = SearchTerm + SearchResult
            //Show only title & description - article
            //articletitle_t & atticledescription_t = fields from solr
            List<SearchResult> searchResults = result.Select(x => new SearchResult()
            {
                SearchResultTitle = x.Fields["articletitle_t"].ToString(),
                SearchResultDescription = x.Fields["articledescription_t"].ToString()
            }).ToList();

            //Fill the searchViewModel object 
            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.Results = searchResults;
            searchViewModel.Term = searchViewModelInput.Term;


            //Provide output after POST request
            //----------------------------------
            //provide full path after the roo
            //return View("/Views/TrnSearch/SResult.cshtml");
            //Note:Bind result in the same view - using combination of 2 models
            //Send the searchViewModel to View
            return View(searchViewModel);
        }
    }
}