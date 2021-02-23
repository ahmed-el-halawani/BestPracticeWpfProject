using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Exceptioins;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.authentication;

namespace BestPractice.Domain.Tests.Services
{
	[TestFixture]
	class AuthenticationTests
	{

		// testFunctionName_Scenario_Result

		private Mock<IAccountDataService> _accountService;
		private Mock<IPasswordHasher> _passwordHasher;
		private IAuthenticationService _auth;

		readonly string _userName = "testUserName";
		readonly string _password = "testPassword";
		private const string Email = "testUser@mail.com";

		delegate Task LoginDelegate(string u,string p);


		[SetUp]
		public void SetupMock()
		{
			_accountService = new Mock<IAccountDataService>();
			_passwordHasher = new Mock<IPasswordHasher>();
			_auth= new AuthenticationService(_accountService.Object,_passwordHasher.Object);

		}

		[Test]
		public async Task Login_TestUserNameWithCorrectPassword_ReturnAccount()
		{
			// Arrange 
			_accountService.Setup(s=>s.GetByUserName(_userName)).ReturnsAsync(new Account(){AccountHolder = new User(){Username = _userName}});

			_passwordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(),_password)).Returns(PasswordVerificationResult.Success);

			// Act
			Account account = await _auth.LogIn(_userName, _password);

			//Assert
			Assert.AreEqual(_userName,account.AccountHolder.Username);
		}

		[Test]
		public void Login_TestUserNameWithInCorrectPassword_ReturnPasswordNotCorrectException()
		{
			// Arrange 
			_accountService.Setup(s=>s.GetByUserName(_userName)).ReturnsAsync(new Account(){AccountHolder = new User(){Username = _userName}});

			_passwordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(),_password)).Returns(PasswordVerificationResult.Failed);

			// Act
			LoginDelegate authDelegate = _auth.LogIn;

			//Assert
			Assert.ThrowsAsync<PasswordNotCorrectException>(() => authDelegate(_userName, _password));
		}


		[Test]
		public  void Login_TestInCorrectUserNameWithCorrectPassword_ReturnUserNotExistExciption()
		{
			// Arrange 
			_accountService.Setup(s=>s.GetByUserName(_userName)).ReturnsAsync((Account) null);

			_passwordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(),_password)).Returns(PasswordVerificationResult.Success);

			// Act
			LoginDelegate authDelegate = _auth.LogIn;

			//Assert
			Assert.ThrowsAsync<UserNotExistExciption>(() => authDelegate(_userName, _password));
		}


		[Test]
		public async Task Register_withMismatchPasswordAndConfirmPassword_returnPasswordMismatch()
		{
			// arrange
			RegisterResult expectedResult = RegisterResult.PasswordMismatch;

			string password = _password;
			string confirmPassword = It.IsAny<string>();

			_accountService.Setup(s=>s.GetByEmail(Email)).ReturnsAsync((Account) null);
			_accountService.Setup(s=>s.GetByUserName(_userName)).ReturnsAsync((Account) null);
			_passwordHasher.Setup(s => s.HashPassword(_password)).Returns(It.IsAny<string>());
			// act
			RegisterResult result = await _auth.Register(_userName, password , confirmPassword, Email);

			// assert
			Assert.AreEqual(expectedResult,result);

		}


		[Test]
		public async Task Register_withExistingEmail_returnEmailIsExist()
		{
			// arrange
			RegisterResult expectedResult = RegisterResult.EmailIsExist;

			_accountService.Setup(s=>s.GetByEmail(Email)).ReturnsAsync(new Account());
			_accountService.Setup(s=>s.GetByUserName(_userName)).ReturnsAsync((Account) null);
			_passwordHasher.Setup(s => s.HashPassword(_password)).Returns(It.IsAny<string>());
			// act
			RegisterResult result = await _auth.Register(_userName, _password, _password, Email);

			// assert
			Assert.AreEqual(expectedResult,result);
		}

		[Test]
		public async Task Register_withExistingUserName_returnUserIsExist()
		{
			// arrange
			RegisterResult expectedResult = RegisterResult.UserIsExist;

			_accountService.Setup(s=>s.GetByEmail(Email)).ReturnsAsync((Account) null);
			_accountService.Setup(s=>s.GetByUserName(_userName)).ReturnsAsync(new Account());
			_passwordHasher.Setup(s => s.HashPassword(_password)).Returns(It.IsAny<string>());
			// act
			RegisterResult result = await _auth.Register(_userName, _password, _password, Email);

			// assert
			Assert.AreEqual(expectedResult,result);
		}







	}
}
