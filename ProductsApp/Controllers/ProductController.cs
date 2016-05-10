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
using System.Web.Http.Description;
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

        /// <summary>
        /// Get all products.
        /// </summary>
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
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(products);
                    response.Headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromMinutes(20)
                    };

                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;

            }
        }

        /// <summary>
        /// Get a product by id.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
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
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(products);
                    response.Headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromMinutes(20)
                    };

                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        /// <summary>
        /// Get a product by name.
        /// </summary>
        /// <param name="name">The name of the product.</param>
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
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(products);
                    response.Headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromMinutes(20)
                    };

                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        /// <summary>
        /// Post a new product.
        /// </summary>
        /// <param name="pProduct">The product that you want to input</param>
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
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(products);
                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        /// <summary>
        /// Update a product by id.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <param name="pProduct">The product that you want to input</param>
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
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(products);
                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
        }

        /// <summary>
        /// Delete a product by id.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        [ApiExplorerSettings(IgnoreApi = true)]
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
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(products);
                    return response;
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                return response;
            }
            //return product.Delete(id);
        }
    }
}