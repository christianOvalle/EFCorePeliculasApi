﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace ApiPeliculasEFCore.CompiledModels
{
    [DbContext(typeof(ApplicationDBContext))]
    public partial class ApplicationDBContextModel : RuntimeModel
    {
        static ApplicationDBContextModel()
        {
            var model = new ApplicationDBContextModel();
            model.Initialize();
            model.Customize();
            _instance = model;
        }

        private static ApplicationDBContextModel _instance;
        public static IModel Instance => _instance;

        partial void Initialize();

        partial void Customize();
    }
}
