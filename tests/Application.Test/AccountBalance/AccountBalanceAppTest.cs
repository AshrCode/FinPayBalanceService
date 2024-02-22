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
        private Mock<IAccountRepository>  _mockAccountRepository;
        private AccountBalanceApp _app;

        [TestInitialize]
        public void Setup()
        {
            _mocklogger = new Mock<ILogger<AccountBalanceApp>>();
            _mockAccountRepository = new Mock<IAccountRepository>();
            _app = new AccountBalanceApp(_mocklogger.Object, _mockAccountRepository.Object);
        }

        /// <summary>
        /// Throws ApiException when invalid ID is passed.
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
        /// Returns UserAccount object when valid ID is passed.
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
    }
}
