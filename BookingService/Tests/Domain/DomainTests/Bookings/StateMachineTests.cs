using Domain.Entities;

namespace DomainTests.Bookings
{
    public class StateMachineTests
    {

        [Fact]
        public void ShouldAlwaysStartWithCreatedStatus()
        {
            var booking = new Booking();

            Assert.Equal(booking.CurrentStatus, Domain.Enums.StatusEnum.Created);
        }

        [Fact]
        public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStates()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.ActionEnum.Pay);
            Assert.Equal(booking.CurrentStatus, Domain.Enums.StatusEnum.Paid);
        }   
        
        [Fact]
        public void ShouldSetStatusToCancelWhenCancelingForABookingWithCreatedStates()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.ActionEnum.Cancel);
            Assert.Equal(booking.CurrentStatus, Domain.Enums.StatusEnum.Canceled);
        } 

        [Fact]
        public void ShouldSetStatusToFinishWhenFinishAPaidBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.ActionEnum.Pay);
            booking.ChangeState(Domain.Enums.ActionEnum.Finish);
            Assert.Equal(booking.CurrentStatus, Domain.Enums.StatusEnum.Finished);
        }

        [Fact]
        public void ShouldSetStatusToReFoundedWhenReFoundingAPaidBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.ActionEnum.Pay);
            booking.ChangeState(Domain.Enums.ActionEnum.Refound);
            Assert.Equal(booking.CurrentStatus, Domain.Enums.StatusEnum.Refounded);
        }

        [Fact]
        public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.ActionEnum.Refound);

            Assert.Equal(booking.CurrentStatus, Domain.Enums.StatusEnum.Created);
        }
        
        [Fact]
        public void ShouldNotChangeStatusWhenRefoundingAFinishedBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.ActionEnum.Pay);
            booking.ChangeState(Domain.Enums.ActionEnum.Finish);
            booking.ChangeState(Domain.Enums.ActionEnum.Refound);

            Assert.Equal(booking.CurrentStatus, Domain.Enums.StatusEnum.Finished);
        }


    }
}