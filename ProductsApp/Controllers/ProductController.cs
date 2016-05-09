#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion

#region Referencies
using Company.Business.Entity;
using Company.DomainModel;
using Company.Security.BasicAuth;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
#endregion

namespace ProductsApp.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        private IProductBUS _product;

        public ProductController(IProductBUS product)
        {
            this._product = product;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            //ProductBUS product = new ProductBUS();
            try
            
            {
                IEnumerable<Product> products = _product.Get();

                if (products == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, products);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, products);
                    response.Headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromMinutes(20)
                    };

                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;

            }
        }

        [AllowAnonymous]
        [Route("~/api/product/{id:int:min(1)}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            // ProductBUS product = new ProductBUS();

            try
            {
                Product products = _product.GetByID(id);

                if (products == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, products);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, products);
                    response.Headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromMinutes(20)
                    };

                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        [AllowAnonymous]
        [Route("~/api/product/{name:alpha:minlength(1)}")]
        public HttpResponseMessage Get(string name)
        {
            HttpResponseMessage response;

            try
            {
                IEnumerable<Product> products = _product.FindByName(name);

                if (products == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, products);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, products);
                    response.Headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromMinutes(20)
                    };

                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        [CustomAuthorizeAttribute(Users = "acc1,acc2")]
        public HttpResponseMessage Post([FromBody]Product pProduct)
        {
            HttpResponseMessage response;
            //ProductBUS product = new ProductBUS();

            try
            {
                IEnumerable<Product> products = _product.Post(pProduct);
                if (products == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, products);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, products);
                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        [CustomAuthorizeAttribute(Users = "acc1,acc3")]
        [Route("~/api/product/{id:int:min(1)}")]
        public HttpResponseMessage Put(int id, [FromBody]Product pProduct)
        {
            HttpResponseMessage response;
            //ProductBUS product = new ProductBUS();

            try
            {
                IEnumerable<Product> products = _product.Put(id, pProduct);

                if (products == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, products);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, products);
                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        [CustomAuthorizeAttribute(Roles = "Admin")]
        [Route("~/api/product/{id:int:min(1)}")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            //ProductBUS product = new ProductBUS();

            try
            {
                IEnumerable<Product> products = _product.Delete(id);
                if (products == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, products);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, products);
                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
            //return product.Delete(id);
        }
    }
}