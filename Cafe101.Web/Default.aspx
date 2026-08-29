<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cafe101.Web._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="position-relative rounded overflow-hidden mb-5" style="min-height: 480px;">
    <img src="~/Content/images/People Cafe101.png" runat="server" alt="Cafe101 coffee"
         class="position-absolute top-0 start-0 w-100 h-100" style="object-fit: cover; z-index: 0;" />
    <div class="position-absolute top-0 start-0 w-100 h-100" style="background: rgba(26,45,76,0.45); z-index: 1;"></div>

<!-- Hero section with image at the top of the Home page -->
    <div class="position-relative container py-5" style="z-index: 2; max-width: 600px;">
        <h1 class="fw-bold text-white display-4">Fuel Your Day,<br>Feed Your Soul</h1>
        <p class="text-white lead">Cafe101 is here to keep you fuelled throughout your day.</p>
        <a href="~/Contact.aspx" runat="server" class="btn btn-light fw-bold px-4 py-2 mt-2">Visit Us</a>
    </div>
</section>
       
<!-- Testimonials Container to group everything together -->
<section class="container my-5">
    <div class="text-center mb-4">
        <h2 class="fw-bold">What Our Customers Say</h2>
        <p class="text-muted">Hear what members of the Cafe101 community have to say.</p>
    </div>

    <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">

        <!-- Testimonial 1 -->
        <div class="col">
            <div class="card h-100 shadow-sm border-0 p-3">
                <div class="card-body">
                    <p class="mb-3">
                        “Cafe101 is my go-to spot between lectures. The food is
                        always convenient and there’s a good variety to choose from.”
                    </p>
                    <p class="fw-bold mb-0">— Thando M.</p>
                </div>
            </div>
        </div>

        <!-- Testimonial 2 -->
        <div class="col">
            <div class="card h-100 shadow-sm border-0 p-3">
                <div class="card-body">
                    <p class="mb-3">
                        “I love being able to grab something quick before my
                        next class. The combo deals are definitely worth it!”
                    </p>
                    <p class="fw-bold mb-0">— Nandi S.</p>
                </div>
            </div>
        </div>

        <!-- Testimonial 3 -->
        <div class="col">
            <div class="card h-100 shadow-sm border-0 p-3">
                <div class="card-body">
                    <p class="mb-3">
                        “The perfect place to get a quick lunch on campus.
                        The portions are good and the prices are student-friendly.”
                    </p>
                    <p class="fw-bold mb-0">— Sipho D.</p>
                </div>
            </div>
        </div>

        <!-- Testimonial 4 -->
        <div class="col">
            <div class="card h-100 shadow-sm border-0 p-3">
                <div class="card-body">
                    <p class="mb-3">
                        “Cafe101 makes those long days on campus a little better.
                        I can quickly grab a drink and something to eat without
                        having to leave campus.”
                    </p>
                    <p class="fw-bold mb-0">— Lerato N.</p>
                </div>
            </div>
        </div>

        <!-- Testimonial 5 -->
        <div class="col">
            <div class="card h-100 shadow-sm border-0 p-3">
                <div class="card-body">
                    <p class="mb-3">
                        “I usually stop by Cafe101 between lectures. There’s
                        always something for when I’m hungry, whether I want
                        a snack or a proper meal.”
                    </p>
                    <p class="fw-bold mb-0">— Ayesha K.</p>
                </div>
            </div>
        </div>

        <!-- Testimonial 6 -->
        <div class="col">
            <div class="card h-100 shadow-sm border-0 p-3">
                <div class="card-body">
                    <p class="mb-3">
                        “The breakfast combos are one of my favourite things
                        to get before class. Quick, convenient and filling!”
                    </p>
                    <p class="fw-bold mb-0">— Sibusiso M.</p>
                </div>
            </div>
        </div>

    </div>
</section>


       <!-- About us section that allows user to use the tab at the top top "jump" to the section on the Home page -->
    <section id="about" class="row align-items-center py-5 mt-4" aria-labelledby="aboutTitle">
    <div class="col-md-6 mb-4 mb-md-0">
        <img src="~/Content/images/Cafe101 Restaurant.png" runat="server" alt="Cafe101 interior" class="w-100 rounded" style="object-fit: cover; max-height: 420px;" />
    </div>
    <div class="col-md-6 ps-md-5">
        <h2 id="aboutTitle" class="fw-bold text-brand">About Us</h2>
        <p>Cafe101 is a campus café situated at UKZN's Westville Campus in Durban, serving students, staff, and visitors with convenient food and refreshments. We aim to create a welcoming space where the campus community can grab a meal, take a break, and recharge between the demands of university life..</p>
        <p class="mb-3">Varsity Drive, Westville, Durban, KwaZulu-Natal</p>
        <div class="text-warning mb-1" style="font-size: 1.25rem;">★★★★★</div>
        <p class="text-muted small">Rated 5 stars by Customers</p>
    </div>
</section>
        <!--Google maps ro find company -->
        <section class="mb-5">
    <h3 class="fw-bold text-brand mb-3">Find Us</h3>
    <div class="ratio ratio-16x9 rounded overflow-hidden">
        <iframe
           src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3461.6088663152!2d30.940432411873093!3d-29.817842320702564!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1ef701007e4825bd%3A0xd3ae54c5da019d4a!2zQ2Fmw6kxMDE!5e0!3m2!1sen!2sza!4v1787357419105!5m2!1sen!2sza" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="strict-origin-when-cross-origin"
            style="border:0;" allowfullscreen loading="lazy" referrerpolicy="no-referrer-when-downgrade">
             </iframe>
        </>
    </div>
</section>
    </main>
</asp:Content>