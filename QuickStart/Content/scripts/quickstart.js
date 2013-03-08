var QuickStart = window["QuickStart"] = {
    Models: {},
    Views: {},
    start: function (tasks) {
        var theTasks = new QuickStart.Models.tasks;
        var tasksView = new QuickStart.Views.LinkView({
            el: '#tasks',
            collection: theTasks
        });

        tasks = tasks ? tasks : [];
        for (var i = 0; i < tasks.length; i++) {
            thetasks.add(tasks[i]);
        }

        // fire this off if ajaxcontinuation is successful
        amplify.subscribe('TaskAdded', function (task) {
            thetasks.add(task);
        });
    }
};         // namespacing

QuickStart.Models.Link = Backbone.Model.extend({});
QuickStart.Models.tasks = Backbone.Collection.extend({
    model: QuickStart.Models.Link
});

Fubutasks.Views.LinkView = Backbone.View.extend({
    template: '#link-template',
    initialize: function () {
        var tmpl = $(this.template).html();
        this.template = _.template(tmpl);
    },
    model: Fubutasks.Models.Link,
    render: function () {
        $(this.el).html(this.template({ model: this.model.toJSON() }));
    }
});

QuickStart.Views.LinkView = Backbone.View.extend({
    initialize: function () {
        this.collection.bind('add', this.onLinkAdded, this);
    },
    onLinkAdded: function (link) {
        var view = new Fubutasks.Views.LinkView({ model: link });
        view.render();
        $(this.el).find('tbody').append($(view.el).find('tr'));
    }
});

$(document).ready(function () {
    $('#AddItem').submit(function () {
        $(this).ajaxSubmit({
            success: function (continuation) {
                // technically, you can standarize this pretty easily
                // sigh...codebetter TC is still broken. when it's back up, this won't be necessary
                if (!continuation.success && !continuation.Success) {
                    // handle the error
                    return;
                }

                // otherwise, we're good to go
                amplify.publish('TaskAdded', continuation.link);
            }
        });
        return false;
    });
});