//Class to represent the Level
function Level(id, assignment, videoURL) {
    var self = this;
    self.id = id;
    self.assignment = assignment;
    self.videoURL = videoURL;
}

function LevelViewModel(id) {
    //Data
    var self = this;
    self.id = id;
    self.level = ko.computed(function () {
        //fetching the local json
        data = JSON.parse(getRemoteFile());
        self.level = new Level(data.exercise[self.id - 1].id, data.exercise[self.id - 1].assignment, data.exercise[self.id - 1].videoURL);
        return self.level;
    }, this);
};

//Helper functions
function getRemoteFile() {
    return $.ajax({
        type: "GET",
        url: '/Data/Text2Speech.json',
        async: false,
        success: function () {
            console.log("Success");
        },
        error: function () {
            console.log("Error");
        }
    }).responseText;
}