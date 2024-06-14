using ContactManager;

namespace ContactManagerTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddContactCase()
        {
            // Arrange
            string name = "John Doe";
            // Act
            List<string> result = Program.AddContact(name);
            // Assert
            Assert.Contains(name, result);
        }
        [Fact]
        public void RemoveContactCase()
        {
            // Arrange
            string name = "Jane smith";
            // Act
            List<string> result = Program.RemoveContact(name);
            // Assert
            Assert.DoesNotContain(name, result);
        }
        [Fact]
        public void ViewAllContactsCase()
        {
            // Arrange
            string name = "John Doe";
            // Act
            List<string> result = Program.ViewAllContacts();
            // Assert
            Assert.Contains(name, result);
        }
        [Fact]
        public void DuplicateCheckContactCase()
        {
            // Arrange
            string name = "John Doe";
            string check = "Contact already exists";
            // Act
            List<string> opreation1 = Program.AddContact(name);
            List<string> opreation2 = Program.AddContact(name);

            string result = Program.CheckDuplicate(name);
            // Assert
            Assert.Equal(check, result);
        }
    }
}