# Simple.ShoppingBasket

## Simple.ShoppingBasket.API 

A .NET Core 2.2 WebApi server using a minimal arhitecure and implemtnation that attempts to fulfill the requirements of an online shopping bag : create /delete shopping bag , add / update / delete products .   

Note: unit tests have been neglected as they would not offer any added value at this point, when more features are added then it will be mandatory to add them. At the moment the client behaves as an integration test .

### web api definition (swagger)

```js
{
   "swagger":"2.0",
   "info":{
      "version":"v1",
      "title":"Simple.ShoppingBasket.API"
   },
   "paths":{
      "/api/Product":{
         "get":{
            "tags":[
               "Product"
            ],
            "operationId":"Get",
            "consumes":[

            ],
            "produces":[
               "text/plain",
               "application/json",
               "text/json"
            ],
            "parameters":[

            ],
            "responses":{
               "200":{
                  "description":"Success",
                  "schema":{
                     "uniqueItems":false,
                     "type":"array",
                     "items":{
                        "$ref":"#/definitions/ProductDto"
                     }
                  }
               }
            }
         }
      },
      "/api/ShoppingCart":{
         "get":{
            "tags":[
               "ShoppingCart"
            ],
            "operationId":"Get",
            "consumes":[

            ],
            "produces":[
               "text/plain",
               "application/json",
               "text/json"
            ],
            "parameters":[

            ],
            "responses":{
               "200":{
                  "description":"Success",
                  "schema":{
                     "uniqueItems":false,
                     "type":"array",
                     "items":{
                        "$ref":"#/definitions/ShoppingCartDto"
                     }
                  }
               }
            }
         },
         "put":{
            "tags":[
               "ShoppingCart"
            ],
            "operationId":"CreateShoppingCart",
            "consumes":[

            ],
            "produces":[
               "text/plain",
               "application/json",
               "text/json"
            ],
            "parameters":[

            ],
            "responses":{
               "200":{
                  "description":"Success",
                  "schema":{
                     "$ref":"#/definitions/ShoppingCartDto"
                  }
               }
            }
         }
      },
      "/api/ShoppingCart/{id}":{
         "get":{
            "tags":[
               "ShoppingCart"
            ],
            "operationId":"Get",
            "consumes":[

            ],
            "produces":[
               "text/plain",
               "application/json",
               "text/json"
            ],
            "parameters":[
               {
                  "name":"id",
                  "in":"path",
                  "required":true,
                  "type":"integer",
                  "format":"int32"
               }
            ],
            "responses":{
               "200":{
                  "description":"Success",
                  "schema":{
                     "$ref":"#/definitions/ShoppingCartDto"
                  }
               }
            }
         },
         "post":{
            "tags":[
               "ShoppingCart"
            ],
            "operationId":"AddOrUpdateProduct",
            "consumes":[
               "application/json-patch+json",
               "application/json",
               "text/json",
               "application/*+json"
            ],
            "produces":[
               "text/plain",
               "application/json",
               "text/json"
            ],
            "parameters":[
               {
                  "name":"id",
                  "in":"path",
                  "required":true,
                  "type":"integer",
                  "format":"int32"
               },
               {
                  "name":"product",
                  "in":"body",
                  "required":false,
                  "schema":{
                     "$ref":"#/definitions/ShoppingCartProductDto"
                  }
               }
            ],
            "responses":{
               "200":{
                  "description":"Success",
                  "schema":{
                     "$ref":"#/definitions/ShoppingCartDto"
                  }
               }
            }
         },
         "delete":{
            "tags":[
               "ShoppingCart"
            ],
            "operationId":"DeleteShoppingCart",
            "consumes":[

            ],
            "produces":[

            ],
            "parameters":[
               {
                  "name":"id",
                  "in":"path",
                  "required":true,
                  "type":"integer",
                  "format":"int32"
               }
            ],
            "responses":{
               "200":{
                  "description":"Success"
               }
            }
         }
      },
      "/api/ShoppingCart/{id}/{pid}":{
         "delete":{
            "tags":[
               "ShoppingCart"
            ],
            "operationId":"DeleteProductFromCart",
            "consumes":[

            ],
            "produces":[
               "text/plain",
               "application/json",
               "text/json"
            ],
            "parameters":[
               {
                  "name":"id",
                  "in":"path",
                  "required":true,
                  "type":"integer",
                  "format":"int32"
               },
               {
                  "name":"pid",
                  "in":"path",
                  "required":true,
                  "type":"integer",
                  "format":"int32"
               }
            ],
            "responses":{
               "200":{
                  "description":"Success",
                  "schema":{
                     "$ref":"#/definitions/ShoppingCartDto"
                  }
               }
            }
         }
      }
   },
   "definitions":{
      "ProductDto":{
         "type":"object",
         "properties":{
            "id":{
               "format":"int32",
               "type":"integer"
            },
            "name":{
               "type":"string"
            },
            "description":{
               "type":"string"
            },
            "price":{
               "format":"double",
               "type":"number"
            }
         }
      },
      "ShoppingCartDto":{
         "type":"object",
         "properties":{
            "id":{
               "format":"int32",
               "type":"integer"
            },
            "products":{
               "uniqueItems":false,
               "type":"array",
               "items":{
                  "$ref":"#/definitions/ShoppingCartProductDto"
               }
            }
         }
      },
      "ShoppingCartProductDto":{
         "type":"object",
         "properties":{
            "id":{
               "format":"int32",
               "type":"integer"
            },
            "quantity":{
               "format":"int32",
               "type":"integer"
            },
            "productId":{
               "format":"int32",
               "type":"integer"
            }
         }
      }
   }
}
```

## Simple.ShoppingBasket.Client

A .NET Core 2.2 console application that is attempting to consume a service `IShoppingCart` to facilitate and prove the usage of the WebAPI :

```csharp
      Task<ShoppingCartDto> CreateShoppingCart(CancellationToken cancellationToken);
      Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken);
      Task<ShoppingCartDto> AddOrUpdateProduct(int shoppingCartId, ShoppingCartProductDto shoppingCartProductDto, CancellationToken cancellationToken);
      Task<ShoppingCartDto> RemoveProduct(int shoppingCartId, int productId, CancellationToken cancellationToken);
      Task RemoveShoppingCart(int shoppingCartId, CancellationToken cancellationToken);
```

