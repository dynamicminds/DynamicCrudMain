namespace DynamicCrud.Api.Service
{
    using AutoMapper;
    using DynamicCrud.Api.Interfaces;
    using DynamicCrud.Api.Mapper;
    using DynamicCrud.Api.Exceptions;
    using DynamicCrud.Dal.EF.CF.Interfaces;

    public class CrudService<Entity, Dto> : ICrudService<Entity, Dto>
        where Entity : class, new()
        where Dto : class
    {
        private readonly ICRUD<Entity> repository;
        private readonly IMapper _mapper;

        public CrudService(ICRUD<Entity> repository, IMapperProfileSetup<CrudMapper> mapperProfile)
        {
            this.repository = repository;
            _mapper = mapperProfile.Mapper;
        }

        public async Task<int> Add(Dto dto)
        {
            string errorMessages = IsValid(dto, true);
            if (!string.IsNullOrEmpty(errorMessages))
            {

                throw new ArgumentException(errorMessages + " are Invalid Parameters");
            }

            var item = _mapper.Map<Entity>(dto);
            await repository.DB.Add(item);
            repository.SaveChanges();
            dynamic insertedData = item;
            return insertedData.Id;
        }

        public async Task<List<Dto>> GetAll()
        {
            var datas = await repository.DB.GetAll();
            return _mapper.Map<List<Dto>>(datas);
        }

        public async Task<Dto> GetById(int id)
        {
            var positiveType = await repository.DB.Get(id);
            return _mapper.Map<Dto>(positiveType);

        }

        public async Task Update(int id, Dto dto)
        {
            string errorMessages = IsValid(dto);
            if (!string.IsNullOrEmpty(errorMessages))
            {

                throw new ArgumentException(errorMessages + " are Invalid Parameters");
            }

            var existingpositiveType = await repository.DB.Get(id);
            if (existingpositiveType == null)
            {
                throw new ObjectNotFoundException($"Invalid id :{id}");
            }
            var items = _mapper.Map<Entity>(dto);
            await repository.DB.Update(items);
            repository.SaveChanges();
        }
        public async Task Delete(int id)
        {
            var data = await repository.DB.Get(id);
            if (data == null)
            {
                throw new ObjectNotFoundException($"Invalid id :{id}");
            }
            await repository.DB.Remove(data);
            repository.SaveChanges();
        }

        private string IsValid(Dto dto,bool isInsert = false)
        {
            //dynamic dtoObject = dto;
            ICrudDto? dtoObject = dto as ICrudDto;
            string result = dtoObject.IsValidData(isInsert);
            //return dtoObject.IsValid(isInsert);
            return result;
        }
    }
}
