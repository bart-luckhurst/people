using People.Api.Entities;
using People.Api.Entities.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using People.Api.Repositories;
using System.Collections.Generic;

namespace People.Api.Services.Test
{
    public class PersonServiceTests
    {
        private Mock<IPersonRepository> mockPersonRepository = new Mock<IPersonRepository>();

        #region CreateAsync
        [Fact]
        public async Task CreateAsync_ForenameNull_RepositoryNotCalled_ValidationException()
        {
            //arrange
            string forename = null;
            string surname = "Valentino";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ForenameEmpty_RepositoryNotCalled_ValidationException()
        {
            //arrange
            string forename = string.Empty;
            string surname = "Valentino";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ForenameWhitespace_RepositoryNotCalled_ValidationException()
        {
            //arrange
            string forename = " ";
            string surname = "Valentino";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ForenameTooLong_RepositoryNotCalled_ValidationException()
        {
            //forename must be less than 64 characters long

            //arrange
            string forename = "Alessandrohasaverylongnamethatisexaclty76characterslongbutshouldbelessthan64";
            string surname = "Valentino";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }

        [Fact]
        public async Task CreateAsync_SurnameNull_RepositoryNotCalled_ValidationException()
        {
            //arrange
            string forename = "Alessandro";
            string surname = null;
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }

        [Fact]
        public async Task CreateAsync_SurnameEmpty_RepositoryNotCalled_ValidationException()
        {
            //arrange
            string forename = "Alessandro";
            string surname = " ";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }
        
        [Fact]
        public async Task CreateAsync_SurnameWhitespace_RepositoryNotCalled_ValidationException()
        {
            //arrange
            string forename = "Alessandro";
            string surname = " ";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }

        [Fact]
        public async Task CreateAsync_SurnameTooLong_RepositoryNotCalled_ValidationException()
        {
            //surname must be less that 64 characters long

            //arrange
            string forename = "Alessandro";
            string surname = "Alessandrohasaverylongsurnamethatisexaclty79characterslongbutshouldbelessthan64";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                Person createdPerson = await personService.CreateAsync(forename,
                    surname);
            });

            //assert
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidInput_RepositoryCalled_ReturnsCreatedPerson()
        {
            //arrange
            string forename = "Alessandro";
            string surname = "Valentino";
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.CreateAsync(forename,
                    surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act
            Person createdPerson = await personService.CreateAsync(forename,
                    surname);

            //assert
            Assert.Equal(createdPerson,
                desiredPerson);
            mockPersonRepository.Verify(x => x.CreateAsync(desiredPerson.Forename,
                    desiredPerson.Surname,
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()),
                Times.Once);
        }
        #endregion

        #region GetAllAsync
        [Fact]
        public async Task GetAllAsync_RepositoryCalled_ReturnsList()
        {
            //arrange
            IEnumerable<Person> allPeople = new List<Person>()
            {
                new Person()
                {
                    Forename = "Alessandro",
                    Surname = "Valentino",
                    DateTimeCreated = DateTime.UtcNow,
                    DateTimeUpdated = DateTime.UtcNow
                },
                new Person()
                {
                    Forename = "Paul",
                    Surname = "Smith",
                    DateTimeCreated = DateTime.UtcNow,
                    DateTimeUpdated = DateTime.UtcNow
                }
            };
            mockPersonRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(allPeople);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act
            IEnumerable<Person> returnedPeople = await personService.GetAllAsync();

            //assert
            Assert.Equal(allPeople, returnedPeople);
            mockPersonRepository.Verify(x => x.GetAllAsync(),
                Times.Once);
        }
        #endregion

        #region GetSingleAsync
        [Fact]
        public async Task GetSingleAsync_DoesntExist_RepositoryCalled_NotFoundException()
        {
            //arrange
            Guid nonExistentId = new Guid();
            Person nonExistentPerson = null;
            mockPersonRepository.Setup(x => x.GetSingleAsync(nonExistentId))
                .ReturnsAsync(nonExistentPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                Person returnedPerson = await personService.GetSingleAsync(nonExistentId);
            });

            //assert
            mockPersonRepository.Verify(x => x.GetSingleAsync(nonExistentId),
                Times.Once);
        }

        [Fact]
        public async Task GetSingleAsync_Exists_RepositoryCalled_ReturnsPerson()
        {
            //arrange
            Guid existentId = new Guid();
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.GetSingleAsync(existentId))
                .ReturnsAsync(desiredPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act
            Person returnedPerson = await personService.GetSingleAsync(existentId);

            //assert
            Assert.Equal(desiredPerson, returnedPerson);
            mockPersonRepository.Verify(x => x.GetSingleAsync(existentId),
                Times.Once);
        }
        #endregion

        #region UpdateAsync
        [Fact]
        public async Task UpdateAsync_DoesntExist_RepositoryNotCalledForUpdate_NotFoundException()
        {
            //arrange
            Guid nonExistentId = new Guid();
            string newForename = "Bob";
            string newSurname = "Jones";
            DateTime dateTimeUpdated = DateTime.UtcNow;
            Person nonExistentPerson = null;
            mockPersonRepository.Setup(x => x.GetSingleAsync(nonExistentId))
                .ReturnsAsync(nonExistentPerson);
            mockPersonRepository.Setup(x => x.UpdateAsync(nonExistentId,
                newForename,
                newSurname,
                dateTimeUpdated));
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                Person returnedPerson = await personService.UpdateAsync(nonExistentId,
                newForename,
                newSurname);
            });

            mockPersonRepository.Verify(x => x.UpdateAsync(nonExistentId,
                newForename,
                newSurname,
                dateTimeUpdated),
                Times.Never);
        }

        [Fact]
        public async Task UpdateAsync_Exists_ValidInput_RepositoryCalledForUpdate_ReturnsPerson()
        {
            //arrange
            Guid existentId = new Guid();
            string oldForename = "Robert";
            string oldSurname = "Johns";
            string newForename = "Bob";
            string newSurname = "Jones";
            DateTime dateTimeCreated = DateTime.UtcNow;
            DateTime dateTimeUpdated = DateTime.UtcNow;
            Person previousPerson = new Person()
            {
                Forename = oldForename,
                Surname = oldSurname,
                DateTimeCreated = dateTimeCreated,
                DateTimeUpdated = dateTimeUpdated
            };
            Person updatedPerson = new Person()
            {
                Forename = newForename,
                Surname = newSurname,
                DateTimeCreated = dateTimeCreated,
                DateTimeUpdated = dateTimeUpdated
            };
            mockPersonRepository.Setup(x => x.GetSingleAsync(existentId))
                .ReturnsAsync(previousPerson);
            mockPersonRepository.Setup(x => x.UpdateAsync(existentId,
                newForename,
                newSurname,
                It.IsAny<DateTime>()))
                .ReturnsAsync(updatedPerson);
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act
            Person returnedPerson = await personService.UpdateAsync(existentId,
                newForename,
                newSurname);

            //assert
            Assert.Equal(updatedPerson, returnedPerson);
            mockPersonRepository.Verify(x => x.UpdateAsync(existentId,
                newForename,
                newSurname,
                It.IsAny<DateTime>()),
                Times.Once);
        }
        #endregion

        #region DeleteAsync
        [Fact]
        public async Task DeleteAsync_DoesntExist_RepositoryNotCalledForDelete_NotFoundException()
        {

            //arrange
            Guid nonExistentId = new Guid();
            mockPersonRepository.Setup(x => x.DeleteAsync(nonExistentId));
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act/assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await personService.DeleteAsync(nonExistentId);
            });
            mockPersonRepository.Verify(x => x.DeleteAsync(nonExistentId), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_Exists_RepositoryCalledForDelete_NoExceptionThrown()
        {
            //arrange
            Guid existentId = new Guid();
            Person desiredPerson = new Person()
            {
                Forename = "Alessandro",
                Surname = "Valentino",
                DateTimeCreated = DateTime.UtcNow,
                DateTimeUpdated = DateTime.UtcNow
            };
            mockPersonRepository.Setup(x => x.GetSingleAsync(existentId))
                .ReturnsAsync(desiredPerson);
            mockPersonRepository.Setup(x => x.DeleteAsync(existentId));
            PersonService personService = new PersonService(mockPersonRepository.Object);

            //act
            await personService.DeleteAsync(existentId);

            //assert
            mockPersonRepository.Verify(x => x.DeleteAsync(existentId), Times.Once);
        }
        #endregion
    }
}
