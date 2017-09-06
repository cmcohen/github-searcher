$(function () {

    $("#search-btn").on('click', function () {
        $.get("/home/getuserinfo", { username: $("#search-txt").val() }, function (user) {
            $("#user-header").text(`${user.name == null ? $("#search-txt").val() : user.name}
                ${user.location == null ? "" : user.location}
                ${user.followers == null ? "" : user.followers}`);
            fillTable(user.repos);
        })
    })

    $("#sort-stars").on('click', function () {
        Sort($("#sort-stars"));
    })

    $("#sort-watchers").on('click', function () {
        Sort($("#sort-watchers"));
    })

    function Sort(button)
    {
        $.get("/home/getuserinfo", { username: $("#search-txt").val() }, function (user) {
            var order = button.hasClass('asc') ? 'desc' : 'asc';
            button.removeClass('asc').removeClass('desc');
            button.addClass(order);
            user.repos.sort(function (a, b) {

                return order == 'asc' ? a.stars - b.stars : b.stars - a.stars;
            })
            fillTable(user.repos);
        }) 
    }

    function fillTable(array)
    {
        $("table tr:gt(0)").remove();
        array.forEach(function (repo) {
            var html = `<tr>
                <td>${repo.name}</td>
                <td>${repo.description == null ? "" : repo.description}</td>
                <td>${repo.language}</td>
                <td>${repo.stars}</td>
                <td>${repo.watchers}</td>
                </tr>`
            $("table").append(html);
        })
    }
     
})