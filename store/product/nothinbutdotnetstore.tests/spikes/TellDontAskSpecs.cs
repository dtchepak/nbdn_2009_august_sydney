 
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;

namespace nothinbutdotnetstore.tests.spikes
{
    public class TellDontAskSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (object))]
        public class when_choosing_to_violate_tell_dont_ask : concern
        {
            context c = () => {};

            because b = () => {};


            it should_strip_the_object_of_all_sensible_behaviour = () =>
            {
                var game = new VideoGame {name = "Max Payne", rating = 10, genre = "Shooter"};

                if (game.genre == "Shooter") {
                    //shooter logic

                }



            };
        }

        public class VideoGame {
            public string name { get; set; }
            public int rating { get; set; }
            public string genre { get; set; }
            public StoreStatus status { get; set; }

            public bool is_applicable_to_people_aged(int age) {
                return false;
            }

            public bool blacklisted() {
                return status.is_blacklisted();
            }
        }
    }

    public class StoreStatus {

        public bool is_blacklisted()
        {
            return true;
        }
    }
}
