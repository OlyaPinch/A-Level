 document.addEventListener("DOMContentLoaded", function () {
      const cardsPerPage = 3; // Change this value to set the number of cards per page
      const cardRow = document.getElementById("card-row");
      const previousBtn = document.getElementById("previous-btn");
      const nextBtn = document.getElementById("next-btn");
      const pagination = document.getElementById("pages");

      let currentPage = 1;
      let totalPages = Math.ceil(cardRow.children.length / cardsPerPage);

      function updatePagination() {
        Array.from(pagination.children).forEach((li) =>
          li.classList.remove("active")
        );
        pagination.children[currentPage - 1].classList.add("active");

        if (currentPage === 1) {
          previousBtn.classList.add("disabled");
        } else {
          previousBtn.classList.remove("disabled");
        }

        if (currentPage === totalPages) {
          nextBtn.classList.add("disabled");
        } else {
          nextBtn.classList.remove("disabled");
        }
      }

      function showCards() {
        for (let i = 0; i < cardRow.children.length; i++) {
          console.log(cardRow.children.length);

          if (
            i < (currentPage - 1) * cardsPerPage ||
            i >= currentPage * cardsPerPage
          ) {
            cardRow.children[i].classList.add("d-none");
          } else {
            cardRow.children[i].classList.remove("d-none");
          }
        }
      }

      function addPagination() {
        for (var i = 1; i <= totalPages; i++) {
          var li = document.createElement("li");
          li.classList.add("page-item");

          var a = document.createElement("a");
          a.classList.add("page-link");
          a.href = "#";
          a.setAttribute("data-page", i);
          a.textContent = i;

          li.appendChild(a);

          pagination.insertBefore(li, pagination.lastElementChild);
        }
      }

      addPagination();

      previousBtn.addEventListener("click", () => {
        if (currentPage > 1) {
          currentPage--;
          updatePagination();
          showCards();
        }
      });

      nextBtn.addEventListener("click", () => {
        if (currentPage < totalPages) {
          currentPage++;
          updatePagination();
          showCards();
        }
      });

      Array.from(pagination.children).forEach((li) => {
        li.firstChild.addEventListener("click", (event) => {
          event.preventDefault();
          currentPage = parseInt(event.target.dataset.page);
          updatePagination();
          showCards();
        });
      });

      updatePagination();
      showCards();
    });