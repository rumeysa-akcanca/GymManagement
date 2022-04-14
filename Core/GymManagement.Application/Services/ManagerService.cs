﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.Validations;
using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateTrainer(TrainerCommandViewModel model)
        {

            var validator = new TrainerValidator();
            validator.ValidateAndThrow(model);

            model.EmployeeDetail.PaymentDate = DateTime.Now;
            model.WorkerContract.CreatedDate = DateTime.Now;
            model.WorkerContract.EndDate = model.WorkerContract.CreatedDate.AddMonths(model.WorkerContract.Duration);
            model.WorkerContract.IsActive = true;
            model.WorkerContract.UpdateDate = DateTime.Now;

            _unitOfWork.EmployeeDetails.Create(model.EmployeeDetail);
            _unitOfWork.WorkerContracts.Create(model.WorkerContract);
            _unitOfWork.SaveChanges();

            var employeeDetail = _unitOfWork.EmployeeDetails
                .Get(e => e.InsuranceNumber == model.EmployeeDetail.InsuranceNumber)
                .FirstOrDefault();

            var workerContract = _unitOfWork.WorkerContracts.GetAll()
                .OrderByDescending(x => x.Id).FirstOrDefault();

            Trainer trainer = new()
            {
                EmployeeDetailId = employeeDetail.Id,
                WorkerContractId = workerContract.Id
            };

            _unitOfWork.Trainers.Create(trainer);

            return _unitOfWork.SaveChanges();
            //Burada Member SingUp yapılacak yani Trainer Login olabilmesi için Users tablosuna eklenecek 
            //TrainerCommandViewModel de UserName,Email vb bilgiler istenecek.
        }

        public bool AddMissionToTrainer(int missionId, int trainerId)
        {
            _unitOfWork.Managers.AddMissionToTrainer(missionId, trainerId);
            return true;
        }

        public List<Member> GetAll()
        {
            return _unitOfWork.Managers.GetAllMembers();
        }
    }
}
