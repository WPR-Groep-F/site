import { Stack, Container, Row, Col } from 'react-bootstrap';
import InviteForm from "../../components/InviteForm.jsx";
import InviteTable from "../../components/InviteTable.jsx";

function Invite(){
    return(
        <Stack gap={4} style={{ zIndex: 1 }}>
            <Container>
                <Row className="d-flex justify-content-center">
                    <Col xs={12} sm={12} md={10} lg={10} xl={10} style={{ zIndex: 1 }}>
                        <InviteForm/>
                    </Col>
                </Row>
            </Container>
            <Container>
                <Row className="d-flex justify-content-center">
                    <Col xs={12} sm={12} md={10} lg={10} xl={10} style={{ zIndex: 1 }}>
                        <InviteTable/>
                    </Col>
                </Row>
            </Container>
        </Stack>
    )
}

export default Invite;