import { Image } from "primereact/image";
import { Layout } from "../../menu/Layout";
import { Card } from "primereact/card";
import { Button } from "primereact/button";

export const Home = () => {
  return (
    <Layout>
      <div style={{ display: "flex" }}>
        <Card>
          <div>
            <Image src="/images/logo.jpg" alt="Лого" width="250" />
          </div>
          <Button
            style={{ borderRadius: "10px" }}
            label="Изменить изображение"
            icon="pi pi-pencil"
          />
        </Card>
        <Card title="Культурно-массовый отдел" subTitle={<span className="pi pi-pencil"><i>Изменить название</i></span>}>
          <div>
            <div style={{ marginBottom: "10px" }}>
              <h5><u>Описание</u> <span className="pi pi-pencil"></span></h5>
              <div><i>Культурно-массовый отдел (КМ) занимается досугом студентов нашего вуза. Большая и слаженная команда делает всё, чтобы на протяжении учебного года студенческая жизнь была красивой и увлекательной. Ни одно массовое мероприятие не обходится без помощи членов отдела в организации и украшениях</i></div>
            </div>
            <div style={{ marginBottom: "10px" }}>
              <h5><u>Цель</u> <span className="pi pi-pencil"></span></h5>
              <div><i>Организация досуга студентов</i></div>
            </div>
            <div style={{ marginBottom: "10px" }}>
              <h5><u>Задачи</u> <span className="pi pi-pencil"></span></h5>
              <div><ul>
                <li><i>Организация досуга студентов</i></li>
                <li><i>Организация досуга студентов</i></li>
                <li><i>Организация досуга студентов</i></li>
                <li><i>Организация досуга студентов</i></li>
                </ul></div>
            </div>
          </div>
        </Card>
      </div>
    </Layout>
  );
};
