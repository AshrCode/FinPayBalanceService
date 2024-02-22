using Application.AccountBalance;
using Common.ApiException;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Persistence.Account;

namespace Application.Test.AccountBalance
{
    [TestClass]
    public class AccountBalanceAppTest
    {
        private Mock<ILogger<AccountBalanceApp>> _mocklogger;
        private Mock<IAccountRepository> _mockAccountRepository;
        private AccountBalanceApp _app;

        [TestInitialize]
        public void Setup()
        {
            _mocklogger = new Mock<ILogger<AccountBalanceApp>>();
            _mockAccountRepository = new Mock<IAccountRepository>();
            _app = new AccountBalanceApp(_mocklogger.Object, _mockAccountRepository.Object);
        }

        /// <summary>
        /// Should throw ApiException when invalid ID is passed.
        /// </summary>
        [TestMethod]
        public async Task GetAsync_ThrowsApiExceptionWhenInValidIdIsPassed()
        {
            // Arrange
            var invalidUserId = Guid.NewGuid();

            // Assert
            await Assert.ThrowsExceptionAsync<ApiException>(() => _app.GetAsync(invalidUserId));
        }

        /// <summary>
        /// Should return UserAccount object when valid ID is passed.
        /// </summary>
        [TestMethod]
        public async Task GetAsync_ReturnsUserAccountWhenValidIdIsPassed()
        {
            // Arrange
            UserAccount userAccount = new();
            _mockAccountRepository.Setup(a => a.GetById(It.IsAny<Guid>()))
                                  .Returns(Task.FromResult(userAccount));

            var validUserId = Guid.NewGuid();

            // Act
            var result = await _app.GetAsync(validUserId);

            // Assert
            Assert.AreEqual(userAccount, result);
        }

        /// <summary>
        /// Should throw ApiException when debit amount is greater than actual balance.
        /// </summary>
        [TestMethod]
        public async Task DebitAmount_ThrowsApiExceptionWhenDebitAmountIsGreaterThanActualBalance()
        {
            // Arrange
            UserAccount userAccount = new() { Balance = 50 };
            _mockAccountRepository.Setup(a => a.GetById(It.IsAny<Guid>()))
                                  .Returns(Task.FromResult(userAccount));


            // Assert
            await Assert.ThrowsExceptionAsync<ApiException>(() => _app.DebitAmount(Guid.NewGuid(), 100));
        }

        /// <summary>
        /// Should return UserAccount when valid debit amount is provided.
        /// </summary>
        [TestMethod]
        public async Task DebitAmount_ReturnsUserAccountWhenValidDebitAmountIsProvided()
        {
            // Arrange
            UserAccount userAccount = new() { Balance = 200 };
            _mockAccountRepository.Setup(a => a.GetById(It.IsAny<Guid>()))
                                  .Returns(Task.FromResult(userAccount));
            // Act
            var result = await _app.DebitAmount(new Guid(), 70);

            // Assert
            Assert.AreEqual(userAccount, result);
        }
    }
}
